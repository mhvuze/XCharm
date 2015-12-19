# XCharm
Simple C# tool for creating comma-seperated charm sheets from MHX savedata for use with various applications.
Save yourself the hassle of manually entering all your precious charms and get right into mix set creation!

###Usage
```
XCharm savedata slotnumber
```

i.e. `XCharm system 1` will read all charms from your first character slot.

###Supported applications
* masax' [Skill Simulator for MHX](http://www.geocities.jp/masax_mh/mhx/): Put CHARM.csv into the `/save/` folder.
* [Ping's MHX Dex](https://www.facebook.com/PingsDex/): Put MyTalisman.csv into the same directory as the executable

Thanks to svanheulen for his [research](https://github.com/svanheulen/mhff/wiki/MHX-system-Format) which saved me some trouble.

*Note:* A homebrew-enabled console is required to dump your savedata.