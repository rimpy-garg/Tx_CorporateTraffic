Feature: ContactsModule
This module covers functionality of contacts module

@TC003_AddContacts_LandLord
Scenario Outline: Contacts_TC003_AddContacts_LandLord
	Given Login to application <LID> and <Password>
	Then Enter record id in Search box and select the lease
	Then Select contacts tab and click on Edit for land lord section
	And Verify the message No contacts specified in contacts section
	Then User Enters valid data <FirstName> and <LastName> and <JobTitle> and <CompanyName> and <Street> and <Town> and <State> and <Pin> and <Country> and <Phone> and <EmailAddress> and <PayeeType> and <VendorNumber> and <FedID> and <TaxID> and <CorporationNumber> and <PayeeSite> and <PaymentMethod> and <BankCode>
	Then Select save contacts and verify the message Contact saved successfully
	Then I do logout from application

	@Source:TC003_AddContacts_LandLord.xlsx
	Examples:
	|LID|Password|FirstName|LastName|JobTitle|CompanyName|Street|Town|State|Pin|Country|Phone|EmailAddress|PayeeType|VendorNumber|FedID|TaxID|CorporationNumber|PayeeSite|PaymentMethod|BankCode|

@TC004_AddContacts_Tenant
Scenario Outline: Contacts_TC004_AddContacts_Tenant
	Given Login to application <LID> and <Password>
	Then Enter record id in Search box and select the lease
	Then Select contacts tab and click on Edit for Tenant section
	And Verify the message No contacts specified in contacts section
	Then User Eners valid data for Tenant<CompanyName> and <Street> and <Town> and <State> and <Pin> and <Country> and <Phone> and <EmailAddress> and <PayeeType> and <VendorNumber> and <FedID> and <TaxID> and <CorporationNumber> and <PayeeSite> and <PaymentMethod> and <BankCode>
	Then Select save contacts and verify the message Contact saved successfully
	Then I do logout from application

	@Source:TC004_AddContacts_Tenant.xlsx
	Examples: 
	|LID|Password|CompanyName|Street|Town|State|Pin|Country|Phone|EmailAddress|PayeeType|VendorNumber|FedID|TaxID|CorporationNumber|PayeeSite|PaymentMethod|BankCode|

@TC005_AddContacts_Payor
Scenario Outline: Contacts_TC005_AddContacts_Payor
	Given Login to application <LID> and <Password>
	Then Enter record id in Search box and select the lease
	Then Select Contacts tab and click on Edit for Payor section
	And Verify the message No contacts specified in contacts section
	Then User Enters valid data for Payor <CompanyName> and <Street> and <Town> and <State> and <Pin> and <Country> and <Phone> and <EmailAddress> and <PayeeType> and <VendorNumber> and <FedID> and <TaxID> and <CorporationNumber> and <PayeeSite> and <PaymentMethod> and <BankCode>
	Then Select save contacts and verify the message Contact saved successfully
	Then I do logout from application

	@Source:TC005_AddContacts_Payor.xlsx
	Examples:
	|LID|Password|CompanyName|Street|Town|State|Pin|Country|Phone|EmailAddress|PayeeType|VendorNumber|FedID|TaxID|CorporationNumber|PayeeSite|PaymentMethod|BankCode|

	
	@TC006_Contacts_CopyToPayee
Scenario Outline: Contacts_TC006_Contacts_CopyToPayee
	Given Login to application <LID> and <Password>
	#And  I Navigate to Lease -> New page
	#Then I entered all the mandatory information for creating new lease form <strRcrdType> and <strClassification> and <strBrand> and <strPropType> and <StrStreetName> and <strTown> and <strState> and <strPIN> and <strCountry> and <strOrganization> and <strRegion> and <strGrpName> and <strOwnerType> and <strRentType> and <strArea> and <strMesrmtArea> and <strLandUnit>
	#When I press Save and Create Lease button
	#Then The default page of lease should be displayed
	Then Enter record id in Search box and select the lease
	Then Select Contacts tab
	#Then Select contacts tab and click on Edit for land lord section
	#And Verify the message No contacts specified in contacts section
	#Then User Enters valid data <FirstName> and <LastName> and <JobTitle> and <CompanyName> and <Street> and <Town> and <State> and <Pin> and <Country> and <Phone> and <EmailAddress> and <PayeeType> and <VendorNumber> and <FedID> and <TaxID> and <CorporationNumber> and <PayeeSite> and <PaymentMethod> and <BankCode>
	#Then Select save contacts and verify the message Contact saved successfully
	Then Click on Copy to Payee link in Landlord section
	#Then Click on Financials tab and verify the Payee details <FirstName> and <LastName> and <JobTitle> and <CompanyName>and <Phone> and <EmailAddress>
	Then Click on Financials tab and verify the Payee details
	And Click on Contacts tab
	Then Click on Copy to Payee link and verify the error message
	Then I do logout from application

	@Source:TC006_Contacts_CopyToPayee.xlsx
	Examples:
	|LID|Password|strRcrdType|strClassification|strBrand| strPropType | StrStreetName | strTown | strState | strPIN | strCountry | strOrganization | strRegion | strGrpName | strOwnerType | strRentType | strArea | strMesrmtArea | strLandUnit|FirstName|LastName|JobTitle|CompanyName|Street|Town|State|Pin|Country|Phone|EmailAddress|PayeeType|VendorNumber|FedID|TaxID|CorporationNumber|PayeeSite|PaymentMethod|BankCode|

