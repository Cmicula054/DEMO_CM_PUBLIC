# Propak Demo Application

##Getting started
This application needs a little work. We need a registration form built. This application should:
* Collect new user information
* Validate that required fields are entered and in the correct format
* Validate that the requested username does not already exist in App_Data/users.xml before the form is submitted
* Let the user pick an account type from a select list provided by the Models.AccountType.ValidAccountTypes property
* Save the submitted information to the users.xml file in the App_Data directory
* Use postmarkapp to send a confirmation e-mail to the e-mail address provided by the user (the api key is provided in the web.config)

##Optional
There are also some _optional_ features that aren't required, but would be nice to have:
* Look up the City and State automatically based on the Zip Code</li>
* Validate that the password has a minimum of eight characters with at least one each:
  * lower-case letter
  * upper-case letter
  * number
  * symbol
            
##Account Information
We need to collect the following information from registering users:
* First Name :eight_spoked_asterisk:
* Last Name :eight_spoked_asterisk:
* Account Type Id :eight_spoked_asterisk:
* Username :eight_spoked_asterisk:
* Password :eight_spoked_asterisk:
* E-Mail Address :eight_spoked_asterisk:
* Phone Number
* Address Line 1 :eight_spoked_asterisk:
* Address Line 2
* City :eight_spoked_asterisk:
* State :eight_spoked_asterisk:
* Zip Code :eight_spoked_asterisk:

Items marked with :eight_spoked_asterisk: are required.
