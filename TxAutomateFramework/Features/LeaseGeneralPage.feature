Feature: LeaseGeneralModule
This module covers all the functionality related to new lease creation

@TC001_Create_Lease
Scenario Outline: LeaseGeneral_TC001_Create_Lease
	Given Login to application <LID> and <Password>
	And  I Navigate to Lease -> New page
	Then I entered all the mandatory information for creating new lease form <strRcrdType> and <strClassification> and <strBrand> and <strPropType> and <StrStreetName> and <strTown> and <strState> and <strPIN> and <strCountry> and <strOrganization> and <strRegion> and <strGrpName> and <strOwnerType> and <strRentType> and <strArea> and <strMesrmtArea> and <strLandUnit>
	When I press Save and Create Lease button
	Then The default page of lease should be displayed
	Then  I do logout from application
	
	@Source:TC001_Create_Lease.xlsx
	Examples:
	|LID|Password|strRcrdType|strClassification|strBrand|strPropType|StrStreetName|strTown|strState|strPIN|strCountry|strOrganization|strRegion|strGrpName|strOwnerType|strRentType|strArea|strMesrmtArea|strLandUnit|


@TC002_EditLease_General_Data
Scenario Outline: LeaseGeneral_TC002_EditLease_General_Data
	Given Login to application <LID> and <Password>
	Then Enter record id in Search box and click on EditAll link
	Then Verify all data in the form  <strRcrdType> and <strClassification> and <strBrand> and <strOrganization> and <strRegion> and <strGrpName> and <strOwnerType> and <strRentType>
	And User updates Location section <strBuildName> and <strYear> and <strCounty> and <strSuite> and <strFloor>
	And User updates Date section 
	And User Updates Area section <strUsable>, <strLand>, <strAreaCust>
	Then Click Save and Return button
	Then I do logout from application

	@Source:TC002_EditLease_General_Data.xlsx
	Examples: 
	|LID|Password|strRcrdType|strClassification|strBrand|strOrganization|strRegion|strGrpName|strOwnerType|strRentType|strBuildName|strYear|strCounty|strSuite|strFloor|strUsable|strLand|strAreaCust|








