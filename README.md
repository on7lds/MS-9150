Metex MS-9150 Communication Program
===================================

Shotcut :You will find the .exe file in the MS-9150/bin/Release folder


![MS-9150](MS-9150.png)


This program communicates with a METEX Universal System.

The software that came originally with the MS-9150 (mine is from 1994) does not run on modern Windows systems.

I have not found a successor to that software, so I connected an old computer and ran that software 
to see what it does to communicate with the Metex. I then implemented this in this software.

The Metex *must* be connected with 5 wires: GND, TxD, RxD, DTR and RTS.

Without the correct signals DTR and RTS it will not work!

This program searches for all COM ports and lets you choose one from a dropdown menu.
All settings are stored in the registry, so next time you start with the same settings.

Have fun with
ON7LDS.