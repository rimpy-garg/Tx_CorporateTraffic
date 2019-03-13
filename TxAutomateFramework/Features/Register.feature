Feature: Register

@Register
@POC
Scenario Outline: Register with new user
	Given navigate to register link
	And Enter Profile Name <Profile Name>
	And Enter Password <Password>
	And Enter PasswordConfirm <Password Confirm>
	And Enter PasswordHint <Password Hint>
	And Enter First Name <First Name>
	And Enter Last Name <Last Name>
	And Enter Street Address <Street Address>
	And Enter City <City>
	And Enter State <State>
	And Enter Zip Code <Zip Code>
	And Enter Office Phone1 <Office Phone 1>
	And Enter Company Name <Company Name>
	And Enter Email <Email>
	Then click on save
	And verify registration
	@source:RegisterFile.xlsx
	Examples: 
	| Profile Name | Password | Password Confirm | Password Hint | First Name | Last Name | Street Address | City | State | Zip Code | Office Phone 1 | Company Name | Email |

	
