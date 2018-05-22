Module defaultConfigurationFile

    Public defaultASIConfiguratinString() As String = { _
        "User={UserName=ASI,UserFullName='Airline-Software Inc.',CarrierCode=AS,", _
        " ", _
        "	FtpHostName=ftp.airline-software.com,", _
        "	FtpPortNumber=21,", _
        "	FtpLoginID=marc,", _
        "	FtpPassword=marc,", _
        "	TransferPointOnScanForm=True,", _
        "	TailNumberOnScanForm=True,", _
        "	CanChangeLocationOnScanForm=True,", _
        "	PasswordRequiredForLocationChangeOnScanForm=True,", _
        "	TreatTransferScansAsLoadScans=False,", _
        "	LoadScansRequireSelectionFromPreset=True,", _
        "	PresetsRequireDestinationSpecifications=True,", _
        "	LockDownReleasedInAdminForm=True,", _
        "	DefaultLocation=EWR,", _
        "	CanCreateBinChangeRecords=True,", _
        "	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=False,", _
        "	DisplayFlightValidationMessages=True,", _
        " ", _
        "       CityList={ BUR, HNL, ITO, JON, KOA, KWA, LAS, LIH, MAJ, MKK, OAK, OGG, PHX, PPG, RAR, YVR }", _
        "	OperationsList=FullList", _
        "   }"}

    Public defaultATAConfigurationString() As String = { _
            "User={UserName=ATA,UserFullName='American Trans Air',CarrierCode=TZ,", _
            " ", _
            "       FtpHostName=ftp.airline-software.com,", _
            "       FtpPortNumber=21,", _
            "       FtpLoginID=tz,", _
            "       FtpPassword=tz4T56,", _
            "       TransferPointOnScanForm=False,", _
            "       TailNumberOnScanForm=False,", _
            "       CanChangeLocationOnScanForm=True,", _
            "       PasswordRequiredForLocationChangeOnScanForm=True,", _
            "       TreatTransferScansAsLoadScans=True,", _
            "       LoadScansRequireSelectionFromPreset=True,", _
            "       PresetsRequireDestinationSpecifications=False,", _
            "       LockDownReleasedInAdminForm=False,", _
            "       DefaultLocation=MDW,", _
            "       CanCreateBinChangeRecords=True,", _
            "       CanCreateBinUploadRecords=False,", _
            "       WarnOnDuplicateScan=False,", _
            "       ", _
            "       Buttons={ ", _
            "               Summary=[Location = (9,8), Size = (76,19), Text='Summary'],", _
            "               Presets=[Location = (87,8), Size = (76,19), Text='Presets'],", _
            "               Admin=[Location = (165,8), Size = (77,19), Text='Admin'],", _
            "               BinChange=[Location = (9,28), Size = (115,19), Text='Cart Change'],", _
            "               Scan=[Location = (127,28), Size = (115,19), Text='Scan']", _
            "       }", _
            "", _
            "       CityList={", _
            "                   AUA, BOS, CID, CLT, CUN, DAY, DCA, DEN, DFW, DSM, EWR, FLL, FNT,", _
            "                  GCM, GDL, GRR, HNL, IND, LAS, LAX, LEX, LGA, LIH, MBJ, MCO, MDW,", _
            "                  MIA, MKE, MLI, MSN, MSP, OGG, PHL, PHX, PIE, PIT, PVR, RSW, SBN,", _
            "                  SEA, SFO, SJC, SJU, SMF, SPI, SRQ, TOL, TPA, ZIH }", _
            " ", _
            "       OperationsList= { Possession,  Load, Transfer, PartialOffload, CompleteOffload, Return, Delivery }", _
            "     }"}


    Public defaultJetBlueConfigurationString() As String = { _
            "User={UserName=JetBlue,UserFullName='Jet Blue Airways',CarrierCode=B6,", _
            "   ", _
            "  	FtpHostName=ftp.airline-software.com,", _
            "  	FtpPortNumber=21,", _
            "  	FtpLoginID=bluejet,", _
            "  	FtpPassword=testb6", _
            "  	TransferPointOnScanForm=True,", _
            "  	TailNumberOnScanForm=True,", _
            "  	CanChangeLocationOnScanForm=False,", _
            "  	PasswordRequiredForLocationChangeOnScanForm=False,", _
            "  	TreatTransferScansAsLoadScans=False,", _
            "  	LoadScansRequireSelectionFromPreset=False,", _
            "  	PresetsRequireDestinationSpecifications=False,", _
            "  	LockDownReleasedInAdminForm=False,", _
            "  	DefaultLocation=EWR,", _
            "  	CanCreateBinChangeRecords=True,", _
            "  	CanCreateBinUploadRecords=True,", _
            "	WarnOnDuplicateScan=False,", _
            "	DisplayFlightValidationMessages=True,", _
            "   ", _
            "  	CityList={", _
            "                   ATL, BOS, BTV, BUF, DEN, FLL, IAD, JFK, LAS, LGB, MCO, MSY, OAK, ONT, PBI, ROC,", _
            "                   RSW, SAN, SEA, SJU, SLC, SYR, TPA}", _
            "   ", _
            "  	OperationsList=FullList,", _
            "       ", _
            "   Buttons={ DEFAULTS} }"}

    Public defaultUSAirwaysConfigurationString() As String = { _
        "User={UserName=USAirways,UserFullName='US Airways',CarrierCode=US,", _
        " ", _
        "	FtpHostName=ftp.airline-software.com,", _
        "	FtpPortNumber=21,", _
        "	FtpLoginID=US,", _
        "	FtpPassword=a1rw@ys,", _
        "	TransferPointOnScanForm=True,", _
        "	TailNumberOnScanForm=True,", _
        "	CanChangeLocationOnScanForm=True,", _
        "	PasswordRequiredForLocationChangeOnScanForm=True,", _
        "	TreatTransferScansAsLoadScans=True,", _
        "	LoadScansRequireSelectionFromPreset=False,", _
        "	PresetsRequireDestinationSpecifications=True,", _
        "	LockDownReleasedInAdminForm=False,", _
        "	DefaultLocation=IAD,", _
        "	CanCreateBinChangeRecords=True,", _
        "	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=False,", _
        "	DisplayFlightValidationMessages=True,", _
        " ", _
        "	CityList={", _
        " ", _
        "                   ABE, ACK, ACV, AGS, AHN, ALB, AMS, ANC, ANU, AOO, ART, ATL, AUA, AUG, AVL, AVP,", _
        "                   AXA, AZO, BDA, BDL, BED, BFD, BGI, BGM, BGR, BHB, BHM, BIL, BKW, BLF, BNA, BOS,", _
        "                   BRU, BTR, BTV, BUF, BWI, BZE, CAE, CAK, CBE, CDG, CHA, CHO, CHS, CID, CKB, CLE,", _
        "                   CLT, CMH, CRW, CUN, CVG, CZM, DAY, DCA, DDC, DEN, DFW, DSM, DTW, DUJ, DXB, EGE,", _
        "                   EIS, ELH, ELM, ERI, EUG, EUX, EVV, EWN, EWR, EYW, EZE, FAT, FAY, FCO, FKL, FLL,", _
        "                   FLO, FOE, FPO, FRA, FSD, FWA, GBD, GCK, GCM, GHB, GNV, GOT, GRR, GSO, GSP, GUC,", _
        "                   GVA, HAJ, HDN, HGR, HHH, HKG, HKY, HPN, HSV, HTS, HVN, HYA, HYS, IAD, IAH, ICN,", _
        "                   ICT, ILM, IND, IPT, ISP, ITH, JAN, JAX, JHW, JST, KIX, LAS, LAX, LBE, LEB, LEX,", _
        "                   LGA, LGW, LIH, LIT, LNK, LNS, LRM, LWB, LYH, MAD, MAN, MBJ, MBS, MCI, MCO, MDT,", _
        "                   MDW, MEL, MEM, MEX, MFR, MGM, MGW, MHH, MHK, MHT, MIA, MKE, MOB, MRY, MSN, MSP,", _
        "                   MSS, MSY, MTJ, MUC, MVY, MYR, NAS, NEV, NRT, NUE, OAJ, OGG, OGS, OKC, OMA, ORD,", _
        "                   ORF, PBI, PFN, PGV, PHF, PHL, PHX, PIT, PKB, PLS, PNS, PQI, PSP, PUJ, PVD, PWM,", _
        "                   RDG, RDU, RIC, RKD, ROA, ROC, RSW, SAB, SAN, SAT, SAV, SBA, SBH, SBN, SBY, SCE,", _
        "                   SDF, SDQ, SEA, SFO, SGF, SHD, SHV, SJO, SJU, SKB, SLN, SNA, SRQ, STL, STT, STX,", _
        "                   SWF, SXM, SYD, SYR, TCB, TLH, TOL, TPA, TRI, TTN, TUL, TXL, TYS, UVF, VPS, XNA,", _
        "                   YOW, YUL, YYZ, ZRH }", _
        " ", _
        "	OperationsList= FullList", _
        "     }"}

    Public defaultPacificAirCargoConfigurationString() As String = { _
        "User={UserName=PacificAirCargo,UserFullName='Pacific Air Cargo',CarrierCode=K4,", _
        "   ", _
        "  	FtpHostName=ftp.airline-software.com,", _
        "  	FtpPortNumber=21,", _
        "  	FtpLoginID=PAC,", _
        "  	FtpPassword=K4RT67,", _
        "  	TransferPointOnScanForm=True,", _
        "  	TailNumberOnScanForm=True,", _
        "  	CanChangeLocationOnScanForm=True,", _
        "  	PasswordRequiredForLocationChangeOnScanForm=False,", _
        "  	TreatTransferScansAsLoadScans=False,", _
        "  	LoadScansRequireSelectionFromPreset=False,", _
        "  	PresetsRequireDestinationSpecifications=False,", _
        "  	LockDownReleasedInAdminForm=False,", _
        "  	DefaultLocation=HNL,", _
        "  	CanCreateBinChangeRecords=True,", _
        "  	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=False,", _
        "	DisplayFlightValidationMessages=True,", _
        " ", _
        " 	CityList={ HNL, LAX, PPG, GUM }", _
        "   ", _
        "  	OperationsList=FullList", _
        "    }"}

    Public defaultMNAviationConfigurationString() As String = { _
        "User={UserName=MNAviation,UserFullName='M and N Aviation',CarrierCode=W4,", _
        "   ", _
        "  	FtpHostName=ftp.airline-software.com,", _
        "  	FtpPortNumber=21,", _
        "  	FtpLoginID=elisco,", _
        "  	FtpPassword=mn417d,", _
        "  	TransferPointOnScanForm=True,", _
        "  	TailNumberOnScanForm=True,", _
        "  	CanChangeLocationOnScanForm=True,", _
        "  	PasswordRequiredForLocationChangeOnScanForm=False,", _
        "  	TreatTransferScansAsLoadScans=False,", _
        "  	LoadScansRequireSelectionFromPreset=False,", _
        "  	PresetsRequireDestinationSpecifications=False,", _
        "  	LockDownReleasedInAdminForm=True,", _
        "  	DefaultLocation=SJU,", _
        "  	CanCreateBinChangeRecords=True,", _
        "  	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=False,", _
        "	DisplayFlightValidationMessages=True,", _
        "       ", _
        "       Buttons={ ", _
        "               Summary=[Location = (15,8), Size = (76,19), Text='Summary'],", _
        "               Presets=[Location = (97,8), Size = (76,19), Text='Presets'],", _
        "               Admin=[Location = (175,8), Size = (76,19), Text='Admin'],", _
        "               BinChange=[Location = (15,27), Size = (115,19), Text='Cart Change'],", _
        "               Scan=[Location = (133,27), Size = (115,19), Text='Scan']", _
        "       }", _
        "   ", _
        "  	CityList={ SJU, STT, STX, VQS, SIG, BQN, PSE }", _
        "   ", _
        "  	OperationsList=FullList", _
        "    }"}

    Public defaultSpiritAirConfigurationString() As String = { _
        "User={UserName=SpiritAir,UserFullName='Spirit Air',CarrierCode=NK,", _
        "   ", _
        "  	FtpHostName=ftp.airline-software.com,", _
        "  	FtpPortNumber=21,", _
        "  	FtpLoginID=???,", _
        "  	FtpPassword=???,", _
        "  	TransferPointOnScanForm=True,", _
        "  	TailNumberOnScanForm=True,", _
        "  	CanChangeLocationOnScanForm=True,", _
        "  	PasswordRequiredForLocationChangeOnScanForm=True,", _
        "  	TreatTransferScansAsLoadScans=False,", _
        "  	LoadScansRequireSelectionFromPreset=False,", _
        "  	PresetsRequireDestinationSpecifications=False,", _
        "  	LockDownReleasedInAdminForm=False,", _
        "  	DefaultLocation=EWR,", _
        "  	CanCreateBinChangeRecords=True,", _
        "  	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=False,", _
        "	DisplayFlightValidationMessages=True,", _
        "   ", _
        "  	CityList={ ACY, CUN, ORD, DEN, DTW, FLL, RSW, LAS, LAX, MYR, LGA, MCO, SJU, TPA, DCA, PBI }", _
        "   ", _
        "  	OperationsList=FullList", _
        "    }"}

    Public defaultRoblexConfigurationString() As String = { _
        "User={UserName=Roblex,UserFullName='Roblex',CarrierCode=7O,", _
        " ", _
        "       FtpHostName=ftp.airline-software.com,", _
        "       FtpPortNumber=21,", _
        "       FtpLoginID=roblex,", _
        "       FtpPassword=7Oxelbor,", _
        "       TransferPointOnScanForm=False,", _
        "       TailNumberOnScanForm=False,", _
        "       CanChangeLocationOnScanForm=True,", _
        "       PasswordRequiredForLocationChangeOnScanForm=False,", _
        "       TreatTransferScansAsLoadScans=True,", _
        "       LoadScansRequireSelectionFromPreset=False,", _
        "       PresetsRequireDestinationSpecifications=False,", _
        "       LockDownReleasedInAdminForm=False,", _
        "       DefaultLocation=SJU,", _
        "       CanCreateBinChangeRecords=True,", _
        "       CanCreateBinUploadRecords=False,", _
        "       WarnOnDuplicateScan=False,", _
        "       ", _
        "       Buttons={ ", _
        "               Summary=[Location = (9,8), Size = (76,19), Text='Summary'],", _
        "               Presets=[Location = (87,8), Size = (76,19), Text='Presets'],", _
        "               Admin=[Location = (165,8), Size = (77,19), Text='Admin'],", _
        "               BinChange=[Location = (9,28), Size = (76,19), Text='Cart Change'],", _
        "               Scan=[Location = (87,28), Size = (76,19), Text='Scan'],", _
        "               Manifest=[Location = (165,28), Size = (76,19), Text='Manifest']", _
        "       }", _
        "", _
        "       CityList={ SJU, STT, STX }", _
        " ", _
        "       OperationsList=FullList}"}

    Public defaultAirFlamencoConfigurationString() As String = { _
        "User={UserName=AirFlamenco,UserFullName='Air Flamenco',CarrierCode=??,", _
        "   ", _
        "  	FtpHostName=ftp.airline-software.com,", _
        "  	FtpPortNumber=21,", _
        "  	FtpLoginID=???,", _
        "  	FtpPassword=???,", _
        "  	TransferPointOnScanForm=True,", _
        "  	TailNumberOnScanForm=True,", _
        "  	CanChangeLocationOnScanForm=True,", _
        "  	PasswordRequiredForLocationChangeOnScanForm=True,", _
        "  	TreatTransferScansAsLoadScans=False,", _
        "  	LoadScansRequireSelectionFromPreset=False,", _
        "  	PresetsRequireDestinationSpecifications=False,", _
        "  	LockDownReleasedInAdminForm=False,", _
        "  	DefaultLocation=EWR,", _
        "  	CanCreateBinChangeRecords=True,", _
        "  	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=False,", _
        "	DisplayFlightValidationMessages=True,", _
        "	TriStateLargeBarcodeCheckBox=True,", _
        "   ", _
        "  	CityList={ SJU, STT, STX, VQS, SIG, BQN, PSE, CPX }", _
        "   ", _
        "  	OperationsList=FullList", _
        "    }"}

    Public defaultOlympicConfigurationString() As String = { _
        "User={UserName=Olympic,UserFullName='Olympic Airlines',CarrierCode=OA,", _
        " ", _
        "	FtpHostName=ftp.airline-software.com,", _
        "	FtpPortNumber=21,", _
        "	FtpLoginID=OA,", _
        "	FtpPassword=O1ymp1c,", _
        "	TransferPointOnScanForm=True,", _
        "	TailNumberOnScanForm=True,", _
        "	CanChangeLocationOnScanForm=True,", _
        "	PasswordRequiredForLocationChangeOnScanForm=True,", _
        "	TreatTransferScansAsLoadScans=True,", _
        "	LoadScansRequireSelectionFromPreset=False,", _
        "	PresetsRequireDestinationSpecifications=True,", _
        "	LockDownReleasedInAdminForm=False,", _
        "	DefaultLocation=IAD,", _
        "	CanCreateBinChangeRecords=True,", _
        "	CanCreateBinUploadRecords=True,", _
        "	WarnOnDuplicateScan=true,", _
        "	DisplayFlightValidationMessages=True,", _
        " ", _
        "	CityList={", _
        " ", _
        "                   ABE, ACK, ACV, AGS, AHN, ALB, AMS, ANC, ANU, AOO, ART, ATL, AUA, AUG, AVL, AVP,", _
        "                   AXA, AZO, BDA, BDL, BED, BFD, BGI, BGM, BGR, BHB, BHM, BIL, BKW, BLF, BNA, BOS,", _
        "                   BRU, BTR, BTV, BUF, BWI, BZE, CAE, CAK, CBE, CDG, CHA, CHO, CHS, CID, CKB, CLE,", _
        "                   CLT, CMH, CRW, CUN, CVG, CZM, DAY, DCA, DDC, DEN, DFW, DSM, DTW, DUJ, DXB, EGE,", _
        "                   EIS, ELH, ELM, ERI, EUG, EUX, EVV, EWN, EWR, EYW, EZE, FAT, FAY, FCO, FKL, FLL,", _
        "                   FLO, FOE, FPO, FRA, FSD, FWA, GBD, GCK, GCM, GHB, GNV, GOT, GRR, GSO, GSP, GUC,", _
        "                   GVA, HAJ, HDN, HGR, HHH, HKG, HKY, HPN, HSV, HTS, HVN, HYA, HYS, IAD, IAH, ICN,", _
        "                   ICT, ILM, IND, IPT, ISP, ITH, JAN, JAX, JHW, JST, KIX, LAS, LAX, LBE, LEB, LEX,", _
        "                   LGA, LGW, LIH, LIT, LNK, LNS, LRM, LWB, LYH, MAD, MAN, MBJ, MBS, MCI, MCO, MDT,", _
        "                   MDW, MEL, MEM, MEX, MFR, MGM, MGW, MHH, MHK, MHT, MIA, MKE, MOB, MRY, MSN, MSP,", _
        "                   MSS, MSY, MTJ, MUC, MVY, MYR, NAS, NEV, NRT, NUE, OAJ, OGG, OGS, OKC, OMA, ORD,", _
        "                   ORF, PBI, PFN, PGV, PHF, PHL, PHX, PIT, PKB, PLS, PNS, PQI, PSP, PUJ, PVD, PWM,", _
        "                   RDG, RDU, RIC, RKD, ROA, ROC, RSW, SAB, SAN, SAT, SAV, SBA, SBH, SBN, SBY, SCE,", _
        "                   SDF, SDQ, SEA, SFO, SGF, SHD, SHV, SJO, SJU, SKB, SLN, SNA, SRQ, STL, STT, STX,", _
        "                   SWF, SXM, SYD, SYR, TCB, TLH, TOL, TPA, TRI, TTN, TUL, TXL, TYS, UVF, VPS, XNA,", _
        "                   YOW, YUL, YYZ, ZRH }", _
        " ", _
        "	OperationsList= FullList", _
        "     }"}

    Public defaultAlohaConfigurationString() As String = { _
        "User={UserName=Aloha,UserFullName='Aloha Airlines',CarrierCode=AQ,", _
        " ", _
        "       FtpHostName=ftp.airline-software.com,", _
        "       FtpPortNumber=21,", _
        "       FtpLoginID=al,", _
        "       FtpPassword=al5N32,", _
        "       TransferPointOnScanForm=False,", _
        "       TailNumberOnScanForm=False,", _
        "       CanChangeLocationOnScanForm=True,", _
        "       PasswordRequiredForLocationChangeOnScanForm=True,", _
        "       TreatTransferScansAsLoadScans=True,", _
        "       LoadScansRequireSelectionFromPreset=True,", _
        "       PresetsRequireDestinationSpecifications=False,", _
        "       LockDownReleasedInAdminForm=False,", _
        "       DefaultLocation=MDW,", _
        "       CanCreateBinChangeRecords=True,", _
        "       CanCreateBinUploadRecords=False,", _
        "       WarnOnDuplicateScan=False,", _
        "       ", _
        "       Buttons={ DEFAULTS }", _
        " ", _
        "       CityList={ BUR, HNL, ITO, JON, KOA, KWA, LAS, LIH, MAJ, MKK, OAK, OGG, PHX, PPG, RAR, YVR }", _
        " ", _
        "       OperationsList= { FULLLIST }", _
        " }"}

    Public defaultConfigurationList()() As String = { _
            defaultASIConfiguratinString, _
            defaultATAConfigurationString, _
            defaultJetBlueConfigurationString, _
            defaultUSAirwaysConfigurationString, _
            defaultPacificAirCargoConfigurationString, _
            defaultMNAviationConfigurationString, _
            defaultSpiritAirConfigurationString, _
            defaultRoblexConfigurationString, _
            defaultAirFlamencoConfigurationString, _
            defaultOlympicConfigurationString, _
            defaultAlohaConfigurationString}

End Module
