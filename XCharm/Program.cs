using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XCharm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Handle argument count
            if (args.Length < 2)
            {
                Console.WriteLine("ERROR: Not enough arguments specified.");
                Console.WriteLine("Use XCharm input charslot");
                return;
            }

            // Initialize
            Console.WriteLine("XCharm by MHVuze\n");

            string input = args[0];
            string output = "CHARM.csv";
            string output_dex = "MyTalisman.csv";
            int charNo;
            long input_size = new FileInfo(input).Length;

            // Handle input, output and arguments
            bool parse = int.TryParse(args[1], out charNo);
            if (parse == false)
            {
                Console.WriteLine("ERROR: Invalid value supplied for charslot.");
                Console.WriteLine("Only numbers between 1 and 3 are valid.");
                return;
            }

            if (charNo > 3 || charNo < 0)
            {
                Console.WriteLine("ERROR: Invalid character slot specified.");
                Console.WriteLine("Only numbers between 1 and 3 are valid.");
                return;
            }

            if (input_size != 0x389B2B)
            {
                Console.WriteLine("ERROR: Invalid filesize. Supply MHX system or system_backup.");
                return;
            }
            
            if (File.Exists(output))
                File.Delete(output);
            if (File.Exists(output_dex))
                File.Delete(output_dex);

            // Process input file
            byte[] save = File.ReadAllBytes(input);
            MemoryStream save_ms = new MemoryStream(save);
            BinaryReader reader = new BinaryReader(save_ms);

            // Read char offsets
            reader.BaseStream.Seek(0x10, SeekOrigin.Begin);
            Int32 char1 = reader.ReadInt32();
            Int32 char2 = reader.ReadInt32();
            Int32 char3 = reader.ReadInt32();

            // Calculate used offset
            Int32 offset = 0;
            if (charNo == 1)
                offset = char1 + 0x04667;
            else if (charNo == 2)
                offset = char2 + 0x04667;
            else if (charNo == 3)
                offset = char3 + 0x04667;

            // Read equipbox
            IDTables.FillTables();
            StreamWriter csv = new StreamWriter(output, false, Encoding.GetEncoding(932));
            StreamWriter csv_dex = new StreamWriter(output_dex, false, Encoding.UTF8);
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            for (int i = 0; i < 1400; i++)
            {
                int category = reader.ReadByte();
                if (category == 0x06)
                {
                    // Read data
                    int type = reader.ReadByte();
                    reader.ReadBytes(0x0A);         // Skip nullspace
                    int skl1 = reader.ReadByte();
                    int skl2 = reader.ReadByte();
                    int skl1_pt = reader.ReadByte();
                    int skl2_pt = reader.ReadByte();
                    int slot = reader.ReadByte();
                    reader.ReadBytes(0x13);         // Skip rest

                    Console.WriteLine(type + ", " + slot + ", " + skl1 + ", " + skl1_pt + ", " + skl2 + ", " + skl2_pt);

                    // MASAX CSV
                    // Assign IDs with strings
                    string type_name;
                    string skl1_name;
                    string skl2_name;
                    IDTables.type_tbl.TryGetValue(type, out type_name);
                    IDTables.skl_tbl.TryGetValue(skl1, out skl1_name);
                    IDTables.skl_tbl.TryGetValue(skl2, out skl2_name);

                    string charm = type_name + "," + slot + "," + skl1_name + "," + skl1_pt + "," + skl2_name + "," + skl2_pt;
                    
                    // Account for null skills / pts
                    if (skl2 == 0)
                        charm = type_name + "," + slot + "," + skl1_name + "," + skl1_pt;

                    csv.WriteLine(charm);

                    // PINGS DEX CSV
                    // Account for Dex peculiarities
                    if (skl1 == 148)
                        skl1 = 1;
                    if (skl2 == 148)
                        skl2 = 1;
                    if (skl2 == 0)
                        skl2 = -1;

                    string charm_dex = type + "," + slot + "," + (skl1 + 1) + "," + skl1_pt + "," + (skl2 + 1) + "," + skl2_pt + ",";

                    csv_dex.WriteLine(charm_dex);
                }
                else
                    reader.ReadBytes(0x23);
            }

            // Cleaning
            csv.Close();
            csv_dex.Close();
            reader.Close();
            save_ms.Close();

            Console.WriteLine("\nINFO: Finished!");
        }
    }
}
