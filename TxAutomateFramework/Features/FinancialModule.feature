Feature: FinancialModule
	This module covers functionality of financial 

@TC007_Financial_Entry_Monthly_Recurring
Scenario Outline: Financials_TC007_Financial_Entry_Monthly_Recurring
	Given Login to application <LID> and <Password>
	Then Enter record id in Search box and select the lease
	Then User clicks on Financial tab and Entries link
	Then Click Add Record button and enter valid data for record section <strCategory> and <strFrequency> and <strAmt> and <strFinType> and <strRecordOption>
	Then Click on Add increases link from planed increase sectionenter valid data <bRecurringIncrease> and <strIncAmt> and <strIncType> and <strTimePeriod> and <strTimeFrequency>
	Then Select Calendar link from Finanical sub  menu
	And  Click on Base Rent and select Date Range as Lease term <strCategoryName> and < strSubCategoryname> and <strYear>
	Then Validate the system will display Base Rent and its subcategory with the monthly breakup <strEntryCategoryName> and <strFinEntryAmt>
	Then I do logout from application

	@Source:TC007_Financial_Entry_Monthly_Recurring.xlsx:TC007
	Examples:
	|LID|Password|strCategory|strFrequency|strAmt|strFinType|strRecordOption|bRecurringIncrease|strIncAmt|strIncType|strTimePeriod|strTimeFrequency|strCategoryName|strSubCategoryname|strYear|strEntryCategoryName|strFinEntryAmt|

@TC008_Financial_Entry_Monthly_OneTime
Scenario Outline: Financials_TC008_Financial_Entry_Monthly_OneTime
	Given Login to application <LID> and <Password>
	Then Enter record id in Search box and select the lease
	Then User clicks on Financial tab and Entries link
	Then Click Add Record button and enter valid data for record section <strCategory> and <strFrequency> and <strAmt> and <strFinType> and <strRecordOption>
	Then Click on Add increases link from planed increase sectionenter valid data <bRecurringIncrease> and <strIncAmt> and <strIncType> and <strTimePeriod> and <strTimeFrequency>
	Then Select Calendar link from Finanical sub  menu
	And  Click on Base Rent and select Date Range as Lease term <strCategoryName> and < strSubCategoryname> and <strYear>
	Then Validate the system will display Base Rent and its subcategory with the monthly breakup <strEntryCategoryName> and <strFinEntryAmt>
	Then I do logout from application

	@Source:TC007_Financial_Entry_Monthly_Recurring.xlsx:TC008
	Examples:
	|LID|Password|strCategory|strFrequency|strAmt|strFinType|strRecordOption|bRecurringIncrease|strIncAmt|strIncType|strTimePeriod|strTimeFrequency|strCategoryName|strSubCategoryname|strYear|strEntryCategoryName|strFinEntryAmt|

