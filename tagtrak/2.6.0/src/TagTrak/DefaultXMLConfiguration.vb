Module defaultXMLConfigurationFile

    Public defaultASIXMLConfigurationString() As String = { _
        " ", _
        "<User>", _
        "        <UserName>ASI</UserName>", _
        "        <UserFullName>Airline-Software, Inc.</UserFullName>", _
        "        <CarrierCode>AS</CarrierCode>", _
        "        <FtpHostName>ftp.asiscan.com</FtpHostName>", _
        "        <FtpPortNumber>21</FtpPortNumber>", _
        "        <FtpLoginID>marc</FtpLoginID>", _
        "        <FtpPassword>p3anuts!</FtpPassword>", _
        "        <TransferPointOnScanForm>true</TransferPointOnScanForm>", _
        "        <TailNumberOnScanForm>true</TailNumberOnScanForm>", _
        "        <CanChangeLocationOnScanForm>true</CanChangeLocationOnScanForm>", _
        "        <PasswordRequiredForLocationChangeOnScanForm>true</PasswordRequiredForLocationChangeOnScanForm>", _
        "        <TreatTransferScansAsLoadScans>true</TreatTransferScansAsLoadScans>", _
        "        <LoadScansRequireSelectionFromPreset>false</LoadScansRequireSelectionFromPreset>", _
        "        <PresetsRequireDestinationSpecifications>false</PresetsRequireDestinationSpecifications>", _
        "        <LockDownReleasedInAdminForm>true</LockDownReleasedInAdminForm>", _
        "        <WarnOnDuplicateScan>True</WarnOnDuplicateScan>", _
        "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
        "        <DisplayInternationalPostOffices>True</DisplayInternationalPostOffices>", _
        "        <IntlPostOfficeList>CA,NZ,US</IntlPostOfficeList>", _
        "        <InternationalMailEnabled>True</InternationalMailEnabled>", _
        "        <InternationalSimpleMailEnabled>True</InternationalSimpleMailEnabled>", _
        "        <MailScanEnabled>False</MailScanEnabled>", _
        "        <MailSimpleScanEnabled>False</MailSimpleScanEnabled>", _
        " ", _
        "       <CityList>", _
        " ", _
        "                   ABE, ACK, ACV, AGS, AHN, ALB, AMS, ANC, ANU, AOO, ART, ATL, AUA, AUG, AVL, AVP,", _
        "                   AXA, AZO, BDA, BDL, BED, BFD, BGI, BGM, BGR, BHB, BHM, BIL, BKW, BLF, BNA, BOS,", _
        "                   BRU, BTR, BTV, BUF, BWI, BZE, CAE, CAK, CBE, CDG, CHA, CHO, CHS, CID, CKB, CLE,", _
        "                   CLT, CMH, CRW, CUN, CVG, CZM, DAY, DCA, DDC, DEN, DFW, DSM, DTW, DUJ, DXB, EGE,", _
        "                   EIS, ELH, ELM, ERI, EUG, EUX, EVV, EWN, EWR, EYW, EZE, FAT, FAY, FCO, FKL, FLL,", _
        "                   FLO, FOE, FPO, FRA, FSD, FWA, GBD, GCK, GCM, GHB, GNV, GOT, GRR, GSO, GSP, GUC,", _
        "                   GVA, HAJ, HDN, HGR, HHH, HKG, HKY, HPN, HSV, HTS, HVN, HYA, HYS, IAD, IAH, ICN,", _
        "                   ICT, ILM, IND, IPT, ISP, ITH, JAN, JAX, JFK, JHW, JST, KIX, LAS, LAX, LBE, LEB, LEX,", _
        "                   LGA, LGW, LIH, LIT, LNK, LNS, LRM, LWB, LYH, MAD, MAN, MBJ, MBS, MCI, MCO, MDT,", _
        "                   MDW, MEL, MEM, MEX, MFR, MGM, MGW, MHH, MHK, MHT, MIA, MKE, MOB, MRY, MSN, MSP,", _
        "                   MSS, MSY, MTJ, MUC, MVY, MYR, NAS, NEV, NRT, NUE, OAJ, OGG, OGS, OKC, OMA, ORD,", _
        "                   ORF, PBI, PFN, PGV, PHF, PHL, PHX, PIT, PKB, PLS, PNS, PQI, PSP, PUJ, PVD, PWM,", _
        "                   RDG, RDU, RIC, RKD, ROA, ROC, RSW, SAB, SAN, SAT, SAV, SBA, SBH, SBN, SBY, SCE,", _
        "                   SDF, SDQ, SEA, SFO, SGF, SHD, SHV, SJO, SJU, SKB, SLN, SNA, SRQ, STL, STT, STX,", _
        "                   SWF, SXM, SYD, SYR, TCB, TLH, TOL, TPA, TRI, TTN, TUL, TXL, TYS, UVF, VPS, XNA,", _
        "                   YOW, YUL, YYZ, ZRH", _
        "       </CityList>", _
        " ", _
        "       <WirelessCityList>", _
        "                   ABE, ACK, ACV, AGS, AHN, ALB, AMS, ANC, ANU, AOO, ART, ATL, AUA, AUG, AVL, AVP,", _
        "                   AXA, AZO, BDA, BDL, BED, BFD, BGI, BGM, BGR, BHB, BHM, BIL, BKW, BLF, BNA, BOS,", _
        "                   BRU, BTR, BTV, BUF, BWI, BZE, CAE, CAK, CBE, CDG, CHA, CHO, CHS, CID, CKB, CLE,", _
        "                   CLT, CMH, CRW, CUN, CVG, CZM, DAY, DCA, DDC, DEN, DFW, DSM, DTW, DUJ, DXB, EGE,", _
        "                   EIS, ELH, ELM, ERI, EUG, EUX, EVV, EWN, EWR, EYW, EZE, FAT, FAY, FCO, FKL, FLL,", _
        "                   FLO, FOE, FPO, FRA, FSD, FWA, GBD, GCK, GCM, GHB, GNV, GOT, GRR, GSO, GSP, GUC,", _
        "                   GVA, HAJ, HDN, HGR, HHH, HKG, HKY, HPN, HSV, HTS, HVN, HYA, HYS, IAD, IAH, ICN,", _
        "                   ICT, ILM, IND, IPT, ISP, ITH, JAN, JAX, JFK, JHW, JST, KIX, LAS, LAX, LBE, LEB, LEX,", _
        "                   LGA, LGW, LIH, LIT, LNK, LNS, LRM, LWB, LYH, MAD, MAN, MBJ, MBS, MCI, MCO, MDT,", _
        "                   MDW, MEL, MEM, MEX, MFR, MGM, MGW, MHH, MHK, MHT, MIA, MKE, MOB, MRY, MSN, MSP,", _
        "                   MSS, MSY, MTJ, MUC, MVY, MYR, NAS, NEV, NRT, NUE, OAJ, OGG, OGS, OKC, OMA, ORD,", _
        "                   ORF, PBI, PFN, PGV, PHF, PHL, PHX, PIT, PKB, PLS, PNS, PQI, PSP, PUJ, PVD, PWM,", _
        "                   RDG, RDU, RIC, RKD, ROA, ROC, RSW, SAB, SAN, SAT, SAV, SBA, SBH, SBN, SBY, SCE,", _
        "                   SDF, SDQ, SEA, SFO, SGF, SHD, SHV, SJO, SJU, SKB, SLN, SNA, SRQ, STL, STT, STX,", _
        "                   SWF, SXM, SYD, SYR, TCB, TLH, TOL, TPA, TRI, TTN, TUL, TXL, TYS, UVF, VPS, XNA,", _
        "                   YOW, YUL, YYZ, ZRH", _
        "       </WirelessCityList>", _
        " ", _
        "       <OperationsList>", _
         "           Possession,  Load, Transfer, PartialOffload, CompleteOffload, Return, Delivery", _
        "       </OperationsList>", _
        " ", _
        "       <InternationalOperationsList>", _
        "           Possession,  Load, Delivery, Partial Offload, Complete Offload, Offline Trns. Conveyed, Offline Trns. Received, Online Transfer, Return", _
        "   </InternationalOperationsList>", _
        "</User>"}

    Public defaultATAXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <CarrierCode>TZ</CarrierCode>", _
    "        <UserName>ATA</UserName>", _
    "        <UserFullName>American Trans Air</UserFullName>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>tz</FtpLoginID>", _
    "        <FtpPassword>tz4T56</FtpPassword>", _
    "        <TransferPointOnScanForm>False</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>False</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>True</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>MDW</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    " ", _
    "        <CityList>", _
    "           AUA, BOS, CID, CLT, CUN, DAY, DCA, DEN, DFW, DSM, EWR, FLL, FNT, GCM, GDL, GRR,", _
    "           HNL, IND, LAS, LAX, LEX, LGA, LIH, MBJ, MCO, MDW, MIA, MKE, MLI, MSN, MSP, OGG,", _
    "           PHL, PHX, PIE, PIT, PVR, RSW, SBN, SEA, SFO, SJC, SJU, SMF, SPI, SRQ, TOL, TPA,", _
    "           ZIH", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "           Possession,  Load, Transfer, PartialOffload, CompleteOffload, Return, Delivery", _
    "        </OperationsList>", _
    " ", _
    "        <Buttons>", _
    "            <Summary>  <Location> 15, 8</Location> <Size> 76,19</Size> <Text>Summary   </Text> </Summary>", _
    "            <Presets>  <Location> 97, 8</Location> <Size> 76,19</Size> <Text>Presets   </Text> </Presets>", _
    "            <Admin>    <Location>175, 8</Location> <Size> 76,19</Size> <Text>Admin     </Text> </Admin>", _
    "            <BinChange><Location> 15,27</Location> <Size>115,19</Size> <Text>Cart Change</Text> </BinChange>", _
    "            <MailScan> <Location>133,27</Location> <Size>115,19</Size> <Text>Scan      </Text> </MailScan>", _
    "        </Buttons>", _
    " ", _
    "</User>"}

    Public defaultJetBlueXMLConfigurationString() As String = { _
        "<User>", _
        " ", _
        "        <UserName>JetBlue</UserName>", _
        "        <UserFullName>Jet Blue Airways</UserFullName>", _
        "        <CarrierCode>B6</CarrierCode>", _
        "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
        "        <FtpPortNumber>21</FtpPortNumber>", _
        "        <FtpLoginID>bluejet</FtpLoginID>", _
        "        <FtpPassword>testb6</FtpPassword>", _
        "        <FtpConnectionDelay>15</FtpConnectionDelay>", _
        "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
        "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
        "        <CanChangeLocationOnScanForm>False</CanChangeLocationOnScanForm>", _
        "        <PasswordRequiredForLocationChangeOnScanForm>False</PasswordRequiredForLocationChangeOnScanForm>", _
        "        <TreatTransferScansAsLoadScans>False</TreatTransferScansAsLoadScans>", _
        "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
        "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
        "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
        "        <DefaultLocation>EWR</DefaultLocation>", _
        "        <CanCreateBinChangeRecords>True</CanCreateBinChangeRecords>", _
        "        <CanCreateBinUploadRecords>True</CanCreateBinUploadRecords>", _
        "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
        "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
        "        <CargoScanEnabled>False</CargoScanEnabled>", _
        "        <BaggageScanEnabled>False</BaggageScanEnabled>", _
        "", _
        "        <CityList>", _
        "           ATL, BOS, BTV, BUF, DEN, FLL, IAD, JFK, LAS, LGB, MCO, MSY, OAK, ONT, PBI, ROC,", _
        "           RSW, SAN, SEA, SJU, SLC, SYR, TPA", _
        "        </CityList>", _
        " ", _
        "        <EthernetCityList>", _
        "           ATL, BOS, BTV, BUF, DEN, FLL, IAD, JFK, LAS, LGB, MCO, MSY, OAK, ONT, PBI, ROC,", _
        "           RSW, SAN, SEA, SJU, SLC, SYR, TPA", _
        "        </EthernetCityList>", _
        " ", _
        "        <OperationsList>", _
        "                FullList", _
        "        </OperationsList>", _
        " ", _
        "       <Buttons>", _
        "               DEFAULTS", _
        "       </Buttons>", _
        " ", _
        "</User>"}

    Public defaultUSAirwaysXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>USAirways</UserName>", _
    "        <UserFullName>US Airways</UserFullName>", _
    "        <CarrierCode>US</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>US</FtpLoginID>", _
    "        <FtpPassword>a1rw@ys</FtpPassword>", _
    "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>False</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>true</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>True</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>IAD</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    "        <CargoScanEnabled>True</CargoScanEnabled>", _
    "        <BaggageScanEnabled>True</BaggageScanEnabled>", _
    " ", _
    "       <CityList>", _
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
    "                   YOW, YUL, YYZ, ZRH", _
    "       </CityList>", _
    " ", _
    "       <WirelessCityList>", _
    "                   MDW, MEL, MEM, MEX, MFR, MGM, MGW, MHH, MHK, MHT, MIA, MKE, MOB, MRY, MSN, MSP,", _
    "                   MSS, MSY, MTJ, MUC, MVY, MYR, NAS, NEV, NRT, NUE, OAJ, OGG, OGS, OKC, OMA, ORD,", _
    "                   ORF, PBI, PFN, PGV, PHF, PHL, PHX, PIT, PKB, PLS, PNS, PQI, PSP, PUJ, PVD, PWM,", _
    "                   RDG, RDU, RIC, RKD, ROA, ROC, RSW, SAB, SAN, SAT, SAV, SBA, SBH, SBN, SBY, SCE,", _
    "                   SDF, SDQ, SEA, SFO, SGF, SHD, SHV, SJO, SJU, SKB, SLN, SNA, SRQ, STL, STT, STX,", _
    "                   SWF, SXM, SYD, SYR, TCB, TLH, TOL, TPA, TRI, TTN, TUL, TXL, TYS, UVF, VPS, XNA,", _
    "                   YOW, YUL, YYZ, ZRH", _
    "       </WirelessCityList>", _
    " ", _
    "       <EthernetCityList>", _
    "                   ABE, ACK, ACV, AGS, AHN, ALB, AMS, ANC, ANU, AOO, ART, ATL, AUA, AUG, AVL, AVP,", _
    "                   AXA, AZO, BDA, BDL, BED, BFD, BGI, BGM, BGR, BHB, BHM, BIL, BKW, BLF, BNA, BOS,", _
    "                   BRU, BTR, BTV, BUF, BWI, BZE, CAE, CAK, CBE, CDG, CHA, CHO, CHS, CID, CKB, CLE,", _
    "                   CLT, CMH, CRW, CUN, CVG, CZM, DAY, DCA, DDC, DEN, DFW, DSM, DTW, DUJ, DXB, EGE,", _
    "                   EIS, ELH, ELM, ERI, EUG, EUX, EVV, EWN, EWR, EYW, EZE, FAT, FAY, FCO, FKL, FLL,", _
    "                   FLO, FOE, FPO, FRA, FSD, FWA, GBD, GCK, GCM, GHB, GNV, GOT, GRR, GSO, GSP, GUC,", _
    "                   GVA, HAJ, HDN, HGR, HHH, HKG, HKY, HPN, HSV, HTS, HVN, HYA, HYS, IAD, IAH, ICN,", _
    "                   ICT, ILM, IND, IPT, ISP, ITH, JAN, JAX, JHW, JST, KIX, LAS, LAX, LBE, LEB, LEX,", _
    "                   LGA, LGW, LIH, LIT, LNK, LNS, LRM, LWB, LYH, MAD, MAN, MBJ, MBS, MCI, MCO, MDT,", _
    "                   YOW, YUL, YYZ, ZRH", _
    "       </EthernetCityList>", _
    " ", _
    "       <OperationsList>", _
    "           Possession,  Load, Transfer, PartialOffload, CompleteOffload, Return, Delivery", _
    "       </OperationsList>", _
    " ", _
    "       <InternationalOperationsList>", _
    "           Possession,  Load, Delivery, Partial Offload, Complete Offload, Offline Trns. Conveyed, Offline Trns. Received, Online Transfer, Return", _
    "   </InternationalOperationsList>", _
    " ", _
    "   <CargoOperationsList>", _
    "       Tender, Load, Remove, Delivery", _
    "   </CargoOperationsList>", _
    " ", _
    "</User>"}

    Public defaultPacificAirCargoXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>PacificAirCargo</UserName>", _
    "        <UserFullName>Pacific Air Cargo</UserFullName>", _
    "        <CarrierCode>K4</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>PAC</FtpLoginID>", _
    "        <FtpPassword>K4RT67</FtpPassword>", _
    "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>False</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>False</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>HNL</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    " ", _
    "        <CityList>", _
    "	        HNL, LAX, PPG, GUM", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "	        FullList", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultMNAviationXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>MNAviation</UserName>", _
    "        <UserFullName>M and N Aviation</UserFullName>", _
    "        <CarrierCode>W4</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>elisco</FtpLoginID>", _
    "        <FtpPassword>mn417d</FtpPassword>", _
    "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>False</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>False</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>True</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>SJU</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    " ", _
    "        <Buttons>", _
    "            <Summary>   <Location> 15, 8</Location> <Size> 76,19</Size> <Text>Summary   </Text> </Summary>", _
    "            <Presets>   <Location> 97, 8</Location> <Size> 76,19</Size> <Text>Presets   </Text> </Presets>", _
    "            <Admin>     <Location>175, 8</Location> <Size> 76,19</Size> <Text>Admin     </Text> </Admin>", _
    "            <BinChange> <Location> 15,27</Location> <Size>115,19</Size> <Text>Cart Change</Text> </BinChange>", _
    "            <Scan>      <Location>133,27</Location> <Size>115,19</Size> <Text>Scan      </Text> </Scan>", _
    "        </Buttons>", _
    " ", _
    "        <CityList>", _
    "	        SJU, STT, STX, VQS, SIG, BQN, PSE", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "	        FullList", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultSpiritAirXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>SpiritAir</UserName>", _
    "        <UserFullName>Spirit Air</UserFullName>", _
    "        <CarrierCode>NK</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>???</FtpLoginID>", _
    "        <FtpPassword>???</FtpPassword>", _
    "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>False</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>EWR</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    " ", _
    "        <CityList>", _
    "	        ACY, CUN, ORD, DEN, DTW, FLL, RSW, LAS, LAX, MYR, LGA, MCO, SJU, TPA, DCA, PBI", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "	        FullList", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultRoblexXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>Roblex</UserName>", _
    "        <UserFullName>Roblex</UserFullName>", _
    "        <CarrierCode>7O</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>roblex</FtpLoginID>", _
    "        <FtpPassword>7Oxelbor</FtpPassword>", _
    "        <TransferPointOnScanForm>False</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>False</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>False</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>SJU</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    " ", _
    "        <Buttons>", _
    "            <Summary>   <Location>  9, 8</Location> <Size>76,19</Size> <Text>Summary   </Text> </Summary>", _
    "            <Presets>   <Location> 87, 8</Location> <Size>76,19</Size> <Text>Presets   </Text> </Presets>", _
    "            <Admin>     <Location>165, 8</Location> <Size>76,19</Size> <Text>Admin     </Text> </Admin>", _
    "            <BinChange> <Location>  9,28</Location> <Size>76,19</Size> <Text>Cart Change</Text> </BinChange>", _
    "            <Scan>      <Location> 87,28</Location> <Size>76,19</Size> <Text>Scan      </Text> </Scan>", _
    "            <Manifest>  <Location>165,28</Location> <Size>76,19</Size> <Text>Manifest  </Text> </Manifest>", _
    "        </Buttons>", _
    " ", _
    "        <CityList>", _
    "	        SJU, STT, STX", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "	        FullList", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultAirFlamencoXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>AirFlamenco</UserName>", _
    "        <UserFullName>Air Flamenco</UserFullName>", _
    "        <CarrierCode>??</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>???</FtpLoginID>", _
    "        <FtpPassword>???</FtpPassword>", _
    "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>False</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>EWR</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    "        <TriStateLargeBarcodeCheckBox>True</TriStateLargeBarcodeCheckBox>", _
    " ", _
    "        <CityList>", _
    "	        SJU, STT, STX, VQS, SIG, BQN, PSE, CPX", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "               FullList", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultOlympicXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>Olympic</UserName>", _
    "        <UserFullName>Olympic Airlines</UserFullName>", _
    "        <CarrierCode>OA</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>OA</FtpLoginID>", _
    "        <FtpPassword>O1ymp1c</FtpPassword>", _
    "        <TransferPointOnScanForm>True</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>True</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>True</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>IAD</DefaultLocation>", _
    "        <WarnOnDuplicateScan>true</WarnOnDuplicateScan>", _
    "        <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    " ", _
    "        <CityList>", _
    "            	  ABE, ACK, ACV, AGS, AHN, ALB, AMS, ANC, ANU, AOO, ART, ATL, AUA, AUG, AVL, AVP,", _
    "            	  AXA, AZO, BDA, BDL, BED, BFD, BGI, BGM, BGR, BHB, BHM, BIL, BKW, BLF, BNA, BOS,", _
    "            	  BRU, BTR, BTV, BUF, BWI, BZE, CAE, CAK, CBE, CDG, CHA, CHO, CHS, CID, CKB, CLE,", _
    "            	  CLT, CMH, CRW, CUN, CVG, CZM, DAY, DCA, DDC, DEN, DFW, DSM, DTW, DUJ, DXB, EGE,", _
    "            	  EIS, ELH, ELM, ERI, EUG, EUX, EVV, EWN, EWR, EYW, EZE, FAT, FAY, FCO, FKL, FLL,", _
    "            	  FLO, FOE, FPO, FRA, FSD, FWA, GBD, GCK, GCM, GHB, GNV, GOT, GRR, GSO, GSP, GUC,", _
    "            	  GVA, HAJ, HDN, HGR, HHH, HKG, HKY, HPN, HSV, HTS, HVN, HYA, HYS, IAD, IAH, ICN,", _
    "            	  ICT, ILM, IND, IPT, ISP, ITH, JAN, JAX, JHW, JST, KIX, LAS, LAX, LBE, LEB, LEX,", _
    "            	  LGA, LGW, LIH, LIT, LNK, LNS, LRM, LWB, LYH, MAD, MAN, MBJ, MBS, MCI, MCO, MDT,", _
    "            	  MDW, MEL, MEM, MEX, MFR, MGM, MGW, MHH, MHK, MHT, MIA, MKE, MOB, MRY, MSN, MSP,", _
    "            	  MSS, MSY, MTJ, MUC, MVY, MYR, NAS, NEV, NRT, NUE, OAJ, OGG, OGS, OKC, OMA, ORD,", _
    "            	  ORF, PBI, PFN, PGV, PHF, PHL, PHX, PIT, PKB, PLS, PNS, PQI, PSP, PUJ, PVD, PWM,", _
    "            	  RDG, RDU, RIC, RKD, ROA, ROC, RSW, SAB, SAN, SAT, SAV, SBA, SBH, SBN, SBY, SCE,", _
    "            	  SDF, SDQ, SEA, SFO, SGF, SHD, SHV, SJO, SJU, SKB, SLN, SNA, SRQ, STL, STT, STX,", _
    "            	  SWF, SXM, SYD, SYR, TCB, TLH, TOL, TPA, TRI, TTN, TUL, TXL, TYS, UVF, VPS, XNA,", _
    "            	  YOW, YUL, YYZ, ZRH", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "                FullList", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultAlohaXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>Aloha<UserName>", _
    "        <UserFullName>Aloha Airlines</UserFullName>", _
    "        <CarrierCode>AQ</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>al</FtpLoginID>", _
    "        <FtpPassword>al5N32</FtpPassword>", _
    "        <TransferPointOnScanForm>False</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>False</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>True</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>MDW</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    " ", _
    "        <Buttons>", _
    "	       DEFAULTS", _
    "        </Buttons>", _
    " ", _
    "        <CityList>", _
    "	        BUR, HNL, ITO, JON, KOA, KWA, LAS, LIH, MAJ, MKK, OAK, OGG, PHX, PPG, RAR, YVR", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "	       FULLLIST", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultAlpineXMLConfigurationString() As String = { _
    " ", _
    "<User>", _
    " ", _
    "        <UserName>Alpine<UserName>", _
    "        <UserFullName>Alpine Airlines</UserFullName>", _
    "        <CarrierCode>5A</CarrierCode>", _
    "        <FtpHostName>ftp.airline-software.com</FtpHostName>", _
    "        <FtpPortNumber>21</FtpPortNumber>", _
    "        <FtpLoginID>5A</FtpLoginID>", _
    "        <FtpPassword>5AXX</FtpPassword>", _
    "        <TransferPointOnScanForm>False</TransferPointOnScanForm>", _
    "        <TailNumberOnScanForm>False</TailNumberOnScanForm>", _
    "        <CanChangeLocationOnScanForm>True</CanChangeLocationOnScanForm>", _
    "        <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "        <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "        <LoadScansRequireSelectionFromPreset>True</LoadScansRequireSelectionFromPreset>", _
    "        <PresetsRequireDestinationSpecifications>False</PresetsRequireDestinationSpecifications>", _
    "        <LockDownReleasedInAdminForm>False</LockDownReleasedInAdminForm>", _
    "        <DefaultLocation>MDW</DefaultLocation>", _
    "        <WarnOnDuplicateScan>False</WarnOnDuplicateScan>", _
    " ", _
    "        <Buttons>", _
    "	       DEFAULTS", _
    "        </Buttons>", _
    " ", _
    "        <CityList>", _
    "	        BUR, HNL, ITO, JON, KOA, KWA, LAS, LIH, MAJ, MKK, OAK, OGG, PHX, PPG, RAR, YVR", _
    "        </CityList>", _
    " ", _
    "        <OperationsList>", _
    "	       FULLLIST", _
    "        </OperationsList>", _
    " ", _
    "</User>"}

    Public defaultRGXMLConfigurationString() As String = { _
    "<User>", _
    "    <UserName>Varig</UserName>", _
    "    <UserFullName>Varig</UserFullName>", _
    "    <CarrierCode>RG</CarrierCode>", _
     "   <FtpHostName>ftp.asiscan.com</FtpHostName>", _
    "    <FtpPortNumber>21</FtpPortNumber>", _
    "    <FtpLoginID>varig</FtpLoginID>", _
    "    <FtpPassword>br@z1l</FtpPassword>", _
    "    <TransferPointOnScanForm>False</TransferPointOnScanForm>", _
    "    <TailNumberOnScanForm>False</TailNumberOnScanForm>", _
    "    <CanChangeLocationOnScanForm>False</CanChangeLocationOnScanForm>", _
    "    <PasswordRequiredForLocationChangeOnScanForm>True</PasswordRequiredForLocationChangeOnScanForm>", _
    "    <TreatTransferScansAsLoadScans>True</TreatTransferScansAsLoadScans>", _
    "    <LoadScansRequireSelectionFromPreset>False</LoadScansRequireSelectionFromPreset>", _
    "    <PresetsRequireDestinationSpecifications>True</PresetsRequireDestinationSpecifications>", _
    "    <WarnOnDuplicateScan>True</WarnOnDuplicateScan>", _
    "    <DisplayFlightValidationMessages>True</DisplayFlightValidationMessages>", _
    "    <MessagesEnabled>True</MessagesEnabled>", _
    "    <CargoScanEnabled>False</CargoScanEnabled>", _
    "    <BaggageScanEnabled>False</BaggageScanEnabled>", _
    "    <InternationalMailEnabled>True</InternationalMailEnabled>", _
    "    <InternationalSimpleMailEnabled>True</InternationalSimpleMailEnabled>", _
    "    <MailScanEnabled>False</MailScanEnabled>", _
    "    <MailSimpleScanEnabled>False</MailSimpleScanEnabled>", _
    "    <DisplayInternationalPostOffices>True</DisplayInternationalPostOffices>", _
    "    <IntlPromptCardit>True</IntlPromptCardit>", _
    "    <IntlCartIdPattern>^[A-Za-z]{3}[0-9]{5}[A-Za-z]{2}$</IntlCartIdPattern>", _
    "    <DefaultIntlPostOffice>US</DefaultIntlPostOffice>", _
     "  <CityList>", _
    "AMS, ASU, BUE, CDG, EZE, FRA, GIG, GRU, JFK, LHR, LIM, LIS, LPB, MAD, MIA, MEX, MVD, MXP, RIO, SCL, SRZ", _
    "   </CityList>", _
    "  <EthernetCityList>", _
    "AMS, ASU, BUE, CDG, EZE, FRA, GIG, GRU, JFK, LHR, LIM, LIS, LPB, MAD, MIA, MEX, MVD, MXP, RIO, SCL, SRZ", _
    "   </EthernetCityList>", _
    "   <AdjunctCarrierList>5L</AdjunctCarrierList>", _
    "   <OperationsList>", _
    "       Possession,  Load, Delivery, Transfer, PartialOffload, CompleteOffload, Return", _
    "   </OperationsList>", _
    "   <InternationalOperationsList>", _
    "       Possession,  Load, Delivery, Partial Offload, Complete Offload, Offline Trns. Conveyed, Offline Trns. Received, Online Transfer, Return", _
    "   </InternationalOperationsList>", _
    "   <IntlSimpleOperationsList>", _
    "       Possession,  Delivery, Offline Trns. Received, Return", _
    "   </IntlSimpleOperationsList>", _
    "   <CargoOperationsList>", _
    "       Tender, Load, Remove, Delivery", _
    "   </CargoOperationsList>", _
    "</User>"}


    Public defaultXMLConfigurationList()() As String = { _
        defaultASIXMLConfigurationString, _
        defaultATAXMLConfigurationString, _
        defaultJetBlueXMLConfigurationString, _
        defaultUSAirwaysXMLConfigurationString, _
        defaultPacificAirCargoXMLConfigurationString, _
        defaultMNAviationXMLConfigurationString, _
        defaultSpiritAirXMLConfigurationString, _
        defaultRoblexXMLConfigurationString, _
        defaultAirFlamencoXMLConfigurationString, _
        defaultOlympicXMLConfigurationString, _
        defaultAlohaXMLConfigurationString, _
        defaultAlpineXMLConfigurationString, _
        defaultASIXMLConfigurationString, _ 
        defaultASIXMLConfigurationString, _
        defaultASIXMLConfigurationString, _
        defaultASIXMLConfigurationString, _
        defaultRGXMLConfigurationString}

End Module
