using System;
using System.Text;
using System.IO;

namespace XCharm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print header
            Console.WriteLine("XCharm by MHVuze\n");

            // Handle argument count
            if (args.Length < 2) { Console.WriteLine("ERROR: Not enough arguments specified.\nUse XCharm input charslot"); return; }

            // Initialize
            string input = args[0];
            string output = "CHARM.csv";
            string output_dex = "MyTalisman.csv";
            string output_ass = "mycharms.txt";
            int charNo;

            // Parse char number
            bool parse = int.TryParse(args[1], out charNo);
            if (parse == false || charNo > 3 || charNo < 1) { Console.WriteLine("ERROR: Invalid value supplied for charslot.\nOnly numbers between 1 and 3 are valid."); return; }

            // Check input file for validity
            if (!File.Exists(input)) { Console.WriteLine("ERROR: Input file not found."); return; }
            long input_size = new FileInfo(input).Length;           

            if (input_size == 0x389B2B) { Console.WriteLine("INFO: MHX system file supplied.\n"); }
            else if (input_size == 0x3D0C2F) { Console.WriteLine("INFO: MHGen system file supplied.\n"); }
            if (input_size !=  0x389B2B && input_size != 0x3D0C2F) { Console.WriteLine("ERROR: Supplied file is neither a valid MHX nor MHGen system file."); return; }

            // Clean up existing output            
            if (File.Exists(output))
                File.Delete(output);
            if (File.Exists(output_dex))
                File.Delete(output_dex);
            if (File.Exists(output_ass))
                File.Delete(output_ass);

            // Process input file
            BinaryReader reader = new BinaryReader(File.OpenRead(input));

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
            StreamWriter csv_ass = new StreamWriter(output_ass, false, Encoding.UTF8);
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
                    sbyte skl1_pt = reader.ReadSByte();
                    sbyte skl2_pt = reader.ReadSByte();
                    int slot = reader.ReadByte();
                    reader.ReadBytes(0x13);         // Skip rest

                    Console.WriteLine(type + ", " + slot + ", " + skl1 + ", " + skl1_pt + ", " + skl2 + ", " + skl2_pt);

                    // Assign IDs with strings
                    string type_name;
                    string skl1_name;
                    string skl2_name;
                    IDTables.type_tbl.TryGetValue(type, out type_name);
                    IDTables.skl_tbl.TryGetValue(skl1, out skl1_name);
                    IDTables.skl_tbl.TryGetValue(skl2, out skl2_name);

                    // MASAX CSV
                    string charm = type_name + "," + slot + "," + skl1_name + "," + skl1_pt + "," + skl2_name + "," + skl2_pt;

                    if (skl2 == 0)
                        charm = type_name + "," + slot + "," + skl1_name + "," + skl1_pt;

                    csv.WriteLine(charm);

                    // ATHENAS A.S.S. CSV
                    string charm_ass = slot + "," + skl1_name + "," + skl1_pt + "," + skl2_name + "," + skl2_pt;

                    if (skl2 == 0)
                        charm_ass = slot + "," + skl1_name + "," + skl1_pt + "," + ",";

                    csv_ass.WriteLine(charm_ass);

                    // PINGS DEX CSV
                    // Account for Dex peculiarities
                    if (skl1 == 148)
                        skl1 = 1;
                    if (skl2 == 148)
                        skl2 = 1;
                    if (skl2 == 0)
                        skl2 = -2;

                    string charm_dex = type + "," + slot + "," + (skl1 + 1) + "," + skl1_pt + "," + (skl2 + 1) + "," + skl2_pt + ",";

                    csv_dex.WriteLine(charm_dex);
                }
                else
                    reader.ReadBytes(0x23);
            }

            // Cleaning
            csv.Close();
            csv_dex.Close();
            csv_ass.Close();
            reader.Close();

            Console.WriteLine("\nINFO: Finished!");
        }
    }
}
