# XCharm
Simple C# tool for creating comma-seperated charm sheets from MHX and MHGen savedata for use with various applications.

Save yourself the hassle of manually entering all your precious charms and get right into mix set creation!

###Usage
`XCharm savedata slotnumber`


i.e. `XCharm system 1` will read all charms from your first character slot.

###Supported applications
* masax' [Skill Simulator for MHX](http://www.geocities.jp/masax_mh/mhx/): Put CHARM.csv into the `/save/` folder
* [Ping's MHX Dex](https://www.facebook.com/PingsDex/): Put MyTalisman.csv into the same directory as the executable
* [Athena's Armor Set Searcher for MHX](http://zippyshare.com/AthenaADP): Put mycharms.txt into the `/Data/` folder

Thanks to svanheulen for his [research](https://github.com/svanheulen/mhff/wiki/MHX-system-Format) which saved me some trouble.

*Note:* XCharm only processes decrypted MHX/MHGen savedata. A homebrew-enabled console is required.
