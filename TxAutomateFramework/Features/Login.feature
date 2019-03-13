Feature: Login

@Login
@POC
Scenario Outline: Login with existing user
	Given Enter Existed Profile Name <Profile Name>
	And Enter Existed user password <Password>
	When User click on login
	Then Verify login
	@source:RegisterFile.xlsx
	Examples: 
	| Profile Name   | Password |
		
	

