1. Download this repo as a zip. Unzip to the desktop.
2. Login to the test LMS (provided in lab) as the username "testadmin" (password supplied in the lab).
3. Click on the admin cog, and select "Manage Extensibility".
4. Within "Id Key Authorization", select "Register an App".
5. Give the application a name, and set the trusted url to "https://apitesttool.desire2learnvalence.com".
6. Register the application.
7. Click to show the application key, and copy both the application ID, and application Key into the file "ApiDemoApplication.exe.config", within the executable directory, as applicationId and applicationKey respectively.
8. In another browser tab, open the api test tool at "https://apitesttool.desire2learnvalence.com".
9. Enter the supplied lms domain for Host, 443 for port, and the application id and key generated previously.
10. Click authenticate and follow through prompt by clicking "continue".
11. New fields "User Id" and "User Key" should be revealed in the api test tool UI. These are going to be our keys for our application's service user.
12. Copy the user id and key to "ApiDemoApplication.exe.config" as serviceUserId and serviceUserKey respectively.
13. Enter the supplied lms domain under lmsUrl in "ApiDemoApplication.exe.config".
14. Open the file user.json and enter some details for a test user.
15. Open the file course.json and enter some details for a test course.
16. Run the application ApiDemoApplication.exe.
17. Return to the browser tab where you are logged into the LMS. Use course search to find the course, and browse the classlist to confirm the user is enrolled.