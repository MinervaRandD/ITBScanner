CABBuilder
==========

        CABBuilder takes files from the Input directory and BIN directory and using CabWiz (under ./CabWiz) 
    packs them up for distribution into .CAB files. CABBuilder creates .CAB files for each specific Device 
    (e.g. Intermec) CPU and OS where applicable.

Configuration
=============

    CABBuilder takes its configuration from two files:
    1. Distributions.xml        - Contains the distributions that need to be built, the names
                                  carriers part of each distribution.
                                  Location set under "<setting name="DistroConfigPath">" in "CABBuilder.exe.config".

    2. CABBuilder.exe.config    - This holds the various configuration settings for CABBuilder, it is analogous to 
                                  old INI files.
                                  Located in the same directory as CABBuilder.exe
    
Input Files
===========

    * BIN Files     - These are AES-256 encrypted files that contain carrier specific configuration and logos.
                      These are created by another utility called ConfigPacker, see the Readme for that for more info.
                      Location set under "<setting name="BINPath">" in "CABBuilder.exe.config".

    * Input Files   - Other files that go into the CAB files are taken from device specific directories under Input.
                      This includes TagTrak.exe and any DLLs required to run TagTrak on that particular divice.
                      Each device specific directory can contain "AutoUpdate.xml" that defines files to be automatically 
                      updated at each CAB build. It lists file names and source directories to use for updates.
                      Location set under "<setting name="InputPath">" in "CABBuilder.exe.config".

Output Files
============

    All output files are placed in a folder defined under "<setting name="CABPath">" in "CABBuilder.exe.config".

    There are 3 types of files placed in the output directory:

        * Carrier Files (In the individual two character carrier sub-directories)
        * Program Files (Under the "TagTrak" sub-directory)
        * Distribution Files (Under the "Distributions" sub-directory)

    Carrier Files:
        These contain carrier specific information, the XML config file and Logos.

    Program Files:
        These contain the actual application, TagTrak, for the various supported devices.

    Distribution Files:
        These contain the full distributions ("Program Files" and "Carrier Files") necessary to install TagTrak 
        for any particular carrier on a supported device.

Output File Usage
=================

    There are two scenarios that define how Output Files could be used:

    1. Local Installation:
        If you have the physical device in front of you, all you have to do is put the appropriate Distribution File 
        (Under the "Distributions" sub-directory) anywhere on the device, tap it to make it install, after it finishes warm 
        boot the device. TagTrak will be automatically installed and started.

    2. Remote (FTP) Updates:
        Got to the FTP site folder for the serial number of the device you want to upgrade (or you can go to the city to deply to 
        the entire city, or the root to deploy globally, this is NOT recommended) and upload the required Carrier Files (from the individual 
        two charachter carrier sub-directories). If you need multiple carriers put a few of these. Also you will need to upload the correct 
        Program File (from the "TagTrak" sub-directory), make sure to select the CAB specific to the device type and operating system you're 
        targeting. That's it, the next time the scanner syncs with the server (with any luck) it will update itself. Note that older versions 
        of TagTrak have trouble with this.

Notes
=====
    * Currently CABBuilder supports Intermec devices only, however it was designed to support any number of devices with any number
      of CPUs running any OS, and can be easily extended in the future.

    * CABBuilder runs as a 4 stage operation:

        1. Auto update any files as defined by AutoUpdate.xml in each Input sub-directory.
    
        2. Build carrier files for all available BIN files. These must contain the version of each BIN in Version.xml contained 
           in the same directory as the BIN. This is normally created by ConfigPacker unless something goes wrong.

        3. Build program files. CABBuilder will figure out the version of TagTrak from the EXE file except the revision, you
           will be prompted to enter this.

        4. Build distribution files. The result files can be made to contain the full version designation if need be, set under 
           "<setting name="FullVersionInDistro">" in "CABBuilder.exe.config".

    * CABBuilder uses CabWiz.exe to build the CAB files, the result of the entire build process is logged under "./Temp/ErrorLogs".
      Any log file containing a line that begins with "Error:" is a failed build.