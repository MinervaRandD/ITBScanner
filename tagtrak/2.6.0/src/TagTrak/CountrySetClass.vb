Public Class CountrySetClass

    Public countryList() As CountryClass = { _
        New CountryClass("AFGHANISTAN", "AF"), _
        New CountryClass("ALAND ISLANDS", "AX"), _
        New CountryClass("ALBANIA", "AL"), _
        New CountryClass("ALGERIA", "DZ"), _
        New CountryClass("AMERICAN SAMOA", "AS"), _
        New CountryClass("ANDORRA", "AD"), _
        New CountryClass("ANGOLA", "AO"), _
        New CountryClass("ANGUILLA", "AI"), _
        New CountryClass("ANTARCTICA", "AQ"), _
        New CountryClass("ANTIGUA AND BARBUDA", "AG"), _
        New CountryClass("ARGENTINA", "AR"), _
        New CountryClass("ARMENIA", "AM"), _
        New CountryClass("ARUBA", "AW"), _
        New CountryClass("AUSTRALIA", "AU"), _
        New CountryClass("AUSTRIA", "AT"), _
        New CountryClass("AZERBAIJAN", "AZ"), _
        New CountryClass("BAHAMAS", "BS"), _
        New CountryClass("BAHRAIN", "BH"), _
        New CountryClass("BANGLADESH", "BD"), _
        New CountryClass("BARBADOS", "BB"), _
        New CountryClass("BELARUS", "BY"), _
        New CountryClass("BELGIUM", "BE"), _
        New CountryClass("BELIZE", "BZ"), _
        New CountryClass("BENIN", "BJ"), _
        New CountryClass("BERMUDA", "BM"), _
        New CountryClass("BHUTAN", "BT"), _
        New CountryClass("BOLIVIA", "BO"), _
        New CountryClass("BOSNIA AND HERZEGOVINA", "BA"), _
        New CountryClass("BOTSWANA", "BW"), _
        New CountryClass("BOUVET ISLAND", "BV"), _
        New CountryClass("BRAZIL", "BR"), _
        New CountryClass("BRITISH INDIAN OCEAN TERRITORY", "IO"), _
        New CountryClass("BRUNEI DARUSSALAM", "BN"), _
        New CountryClass("BULGARIA", "BG"), _
        New CountryClass("BURKINA FASO", "BF"), _
        New CountryClass("BURUNDI", "BI"), _
        New CountryClass("CAMBODIA", "KH"), _
        New CountryClass("CAMEROON", "CM"), _
        New CountryClass("CANADA", "CA"), _
        New CountryClass("CAPE VERDE", "CV"), _
        New CountryClass("CAYMAN ISLANDS", "KY"), _
        New CountryClass("CENTRAL AFRICAN REPUBLIC", "CF"), _
        New CountryClass("CHAD", "TD"), _
        New CountryClass("CHILE", "CL"), _
        New CountryClass("CHINA", "CN"), _
        New CountryClass("CHRISTMAS ISLAND", "CX"), _
        New CountryClass("COCOS (KEELING) ISLANDS", "CC"), _
        New CountryClass("COLOMBIA", "CO"), _
        New CountryClass("COMOROS", "KM"), _
        New CountryClass("CONGO", "CG"), _
        New CountryClass("CONGO, DEMOCRATIC REPUBLIC OF", "CD"), _
        New CountryClass("COOK ISLANDS", "CK"), _
        New CountryClass("COSTA RICA", "CR"), _
        New CountryClass("COTE D'IVOIRE", "CI"), _
        New CountryClass("CROATIA", "HR"), _
        New CountryClass("CUBA", "CU"), _
        New CountryClass("CYPRUS", "CY"), _
        New CountryClass("CZECH REPUBLIC", "CZ"), _
        New CountryClass("DENMARK", "DK"), _
        New CountryClass("DJIBOUTI", "DJ"), _
        New CountryClass("DOMINICA", "DM"), _
        New CountryClass("DOMINICAN REPUBLIC", "DO"), _
        New CountryClass("ECUADOR", "EC"), _
        New CountryClass("EGYPT", "EG"), _
        New CountryClass("EL SALVADOR", "SV"), _
        New CountryClass("EQUATORIAL GUINEA", "GQ"), _
        New CountryClass("ERITREA", "ER"), _
        New CountryClass("ESTONIA", "EE"), _
        New CountryClass("ETHIOPIA", "ET"), _
        New CountryClass("FALKLAND ISLANDS (MALVINAS)", "FK"), _
        New CountryClass("FAROE ISLANDS", "FO"), _
        New CountryClass("FIJI", "FJ"), _
        New CountryClass("FINLAND", "FI"), _
        New CountryClass("FRANCE", "FR"), _
        New CountryClass("FRENCH GUIANA", "GF"), _
        New CountryClass("FRENCH POLYNESIA", "PF"), _
        New CountryClass("FRENCH SOUTHERN TERRITORIES", "TF"), _
        New CountryClass("GABON", "GA"), _
        New CountryClass("GAMBIA", "GM"), _
        New CountryClass("GEORGIA", "GE"), _
        New CountryClass("GERMANY", "DE"), _
        New CountryClass("GHANA", "GH"), _
        New CountryClass("GIBRALTAR", "GI"), _
        New CountryClass("GREECE", "GR"), _
        New CountryClass("GREENLAND", "GL"), _
        New CountryClass("GRENADA", "GD"), _
        New CountryClass("GUADELOUPE", "GP"), _
        New CountryClass("GUAM", "GU"), _
        New CountryClass("GUATEMALA", "GT"), _
        New CountryClass("GUINEA", "GN"), _
        New CountryClass("GUINEA-BISSAU", "GW"), _
        New CountryClass("GUYANA", "GY"), _
        New CountryClass("HAITI", "HT"), _
        New CountryClass("HEARD ISLAND AND MCDONALD ISLANDS", "HM"), _
        New CountryClass("HOLY SEE (VATICAN CITY STATE)", "VA"), _
        New CountryClass("HONDURAS", "HN"), _
        New CountryClass("HONG KONG", "HK"), _
        New CountryClass("HUNGARY", "HU"), _
        New CountryClass("ICELAND", "IS"), _
        New CountryClass("INDIA", "IN"), _
        New CountryClass("INDONESIA", "ID"), _
        New CountryClass("IRAN, ISLAMIC REPUBLIC OF", "IR"), _
        New CountryClass("IRAQ", "IQ"), _
        New CountryClass("IRELAND", "IE"), _
        New CountryClass("ISRAEL", "IL"), _
        New CountryClass("ITALY", "IT"), _
        New CountryClass("JAMAICA", "JM"), _
        New CountryClass("JAPAN", "JP"), _
        New CountryClass("JORDAN", "JO"), _
        New CountryClass("KAZAKHSTAN", "KZ"), _
        New CountryClass("KENYA", "KE"), _
        New CountryClass("KIRIBATI", "KI"), _
        New CountryClass("KOREA, DEMOCRATIC PEOPLE'S REPUBLIC OF", "KP"), _
        New CountryClass("KOREA, REPUBLIC OF", "KR"), _
        New CountryClass("KUWAIT", "KW"), _
        New CountryClass("KYRGYZSTAN", "KG"), _
        New CountryClass("LAO PEOPLE'S DEMOCRATIC REPUBLIC", "LA"), _
        New CountryClass("LATVIA", "LV"), _
        New CountryClass("LEBANON", "LB"), _
        New CountryClass("LESOTHO", "LS"), _
        New CountryClass("LIBERIA", "LR"), _
        New CountryClass("LIBYAN ARAB JAMAHIRIYA", "LY"), _
        New CountryClass("LIECHTENSTEIN", "LI"), _
        New CountryClass("LITHUANIA", "LT"), _
        New CountryClass("LUXEMBOURG", "LU"), _
        New CountryClass("MACAO", "MO"), _
        New CountryClass("MACEDONIA, THE FORMER YUGOSLAV REPUBLIC OF", "MK"), _
        New CountryClass("MADAGASCAR", "MG"), _
        New CountryClass("MALAWI", "MW"), _
        New CountryClass("MALAYSIA", "MY"), _
        New CountryClass("MALDIVES", "MV"), _
        New CountryClass("MALI", "ML"), _
        New CountryClass("MALTA", "MT"), _
        New CountryClass("MARSHALL ISLANDS", "MH"), _
        New CountryClass("MARTINIQUE", "MQ"), _
        New CountryClass("MAURITANIA", "MR"), _
        New CountryClass("MAURITIUS", "MU"), _
        New CountryClass("MAYOTTE", "YT"), _
        New CountryClass("MEXICO", "MX"), _
        New CountryClass("MICRONESIA, FEDERATED STATES OF", "FM"), _
        New CountryClass("MOLDOVA, REPUBLIC OF", "MD"), _
        New CountryClass("MONACO", "MC"), _
        New CountryClass("MONGOLIA", "MN"), _
        New CountryClass("MONTSERRAT", "MS"), _
        New CountryClass("MOROCCO", "MA"), _
        New CountryClass("MOZAMBIQUE", "MZ"), _
        New CountryClass("MYANMAR", "MM"), _
        New CountryClass("NAMIBIA", "NA"), _
        New CountryClass("NAURU", "NR"), _
        New CountryClass("NEPAL", "NP"), _
        New CountryClass("NETHERLANDS", "NL"), _
        New CountryClass("NETHERLANDS ANTILLES", "AN"), _
        New CountryClass("NEW CALEDONIA", "NC"), _
        New CountryClass("NEW ZEALAND", "NZ"), _
        New CountryClass("NICARAGUA", "NI"), _
        New CountryClass("NIGER", "NE"), _
        New CountryClass("NIGERIA", "NG"), _
        New CountryClass("NIUE", "NU"), _
        New CountryClass("NORFOLK ISLAND", "NF"), _
        New CountryClass("NORTHERN MARIANA ISLANDS", "MP"), _
        New CountryClass("NORWAY", "NO"), _
        New CountryClass("OMAN", "OM"), _
        New CountryClass("PAKISTAN", "PK"), _
        New CountryClass("PALAU", "PW"), _
        New CountryClass("PALESTINIAN TERRITORY, OCCUPIED", "PS"), _
        New CountryClass("PANAMA", "PA"), _
        New CountryClass("PAPUA NEW GUINEA", "PG"), _
        New CountryClass("PARAGUAY", "PY"), _
        New CountryClass("PERU", "PE"), _
        New CountryClass("PHILIPPINES", "PH"), _
        New CountryClass("PITCAIRN", "PN"), _
        New CountryClass("POLAND", "PL"), _
        New CountryClass("PORTUGAL", "PT"), _
        New CountryClass("PUERTO RICO", "PR"), _
        New CountryClass("QATAR", "QA"), _
        New CountryClass("RÉUNION", "RE"), _
        New CountryClass("ROMANIA", "RO"), _
        New CountryClass("RUSSIAN FEDERATION", "RU"), _
        New CountryClass("RWANDA", "RW"), _
        New CountryClass("SAINT HELENA", "SH"), _
        New CountryClass("SAINT KITTS AND NEVIS", "KN"), _
        New CountryClass("SAINT LUCIA", "LC"), _
        New CountryClass("SAINT PIERRE AND MIQUELON", "PM"), _
        New CountryClass("SAINT VINCENT AND THE GRENADINES", "VC"), _
        New CountryClass("SAMOA", "WS"), _
        New CountryClass("SAN MARINO", "SM"), _
        New CountryClass("SAO TOME AND PRINCIPE", "ST"), _
        New CountryClass("SAUDI ARABIA", "SA"), _
        New CountryClass("SENEGAL", "SN"), _
        New CountryClass("SERBIA AND MONTENEGRO", "CS"), _
        New CountryClass("SEYCHELLES", "SC"), _
        New CountryClass("SIERRA LEONE", "SL"), _
        New CountryClass("SINGAPORE", "SG"), _
        New CountryClass("SLOVAKIA", "SK"), _
        New CountryClass("SLOVENIA", "SI"), _
        New CountryClass("SOLOMON ISLANDS", "SB"), _
        New CountryClass("SOMALIA", "SO"), _
        New CountryClass("SOUTH AFRICA", "ZA"), _
        New CountryClass("SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", "GS"), _
        New CountryClass("SPAIN", "ES"), _
        New CountryClass("SRI LANKA", "LK"), _
        New CountryClass("SUDAN", "SD"), _
        New CountryClass("SURINAME", "SR"), _
        New CountryClass("SVALBARD AND JAN MAYEN", "SJ"), _
        New CountryClass("SWAZILAND", "SZ"), _
        New CountryClass("SWEDEN", "SE"), _
        New CountryClass("SWITZERLAND", "CH"), _
        New CountryClass("SYRIAN ARAB REPUBLIC", "SY"), _
        New CountryClass("TAIWAN, PROVINCE OF CHINA", "TW"), _
        New CountryClass("TAJIKISTAN", "TJ"), _
        New CountryClass("TANZANIA, UNITED REPUBLIC OF", "TZ"), _
        New CountryClass("THAILAND", "TH"), _
        New CountryClass("TIMOR-LESTE", "TL"), _
        New CountryClass("TOGO", "TG"), _
        New CountryClass("TOKELAU", "TK"), _
        New CountryClass("TONGA", "TO"), _
        New CountryClass("TRINIDAD AND TOBAGO", "TT"), _
        New CountryClass("TUNISIA", "TN"), _
        New CountryClass("TURKEY", "TR"), _
        New CountryClass("TURKMENISTAN", "TM"), _
        New CountryClass("TURKS AND CAICOS ISLANDS", "TC"), _
        New CountryClass("TUVALU", "TV"), _
        New CountryClass("UGANDA", "UG"), _
        New CountryClass("UKRAINE", "UA"), _
        New CountryClass("UNITED ARAB EMIRATES", "AE"), _
        New CountryClass("UNITED KINGDOM", "GB"), _
        New CountryClass("UNITED STATES", "US"), _
        New CountryClass("UNITED STATES MINOR OUTLYING ISLANDS", "UM"), _
        New CountryClass("URUGUAY", "UY"), _
        New CountryClass("UZBEKISTAN", "UZ"), _
        New CountryClass("VANUATU", "VU"), _
        New CountryClass("VENEZUELA", "VE"), _
        New CountryClass("VIET NAM", "VN"), _
        New CountryClass("VIRGIN ISLANDS, BRITISH", "VG"), _
        New CountryClass("VIRGIN ISLANDS, U.S. ", "VI"), _
        New CountryClass("WALLIS AND FUTUNA", "WF"), _
        New CountryClass("WESTERN SAHARA", "EH"), _
        New CountryClass("YEMEN", "YE"), _
        New CountryClass("ZAMBIA", "ZM"), _
        New CountryClass("ZIMBABWE", "ZW")}

    Public countryCodeList() As String

    Public Sub New()

        Dim airport As locationClass

        Dim countryListLength As Integer = Me.countryList.Length
        Dim ilmt As Integer = countryListLength - 1

        ReDim countryCodeList(ilmt)

        Dim i As Integer

        For i = 0 To ilmt
            countryCodeList(i) = Me.countryList(i).countryCode
        Next

        Array.Sort(countryCodeList)

    End Sub
End Class
