# ConnectionUI

Standard connection toolbar for WinForms apps that need a SQL Server connection in a dropdown. Nuget package **AoConnnectionUI**.

After installing the package, right click on the VS toolbox and Add Items from your project directory /bin/Debug/ConnectionUI.dll. This will add **DbConnection** toolbar to the toolbox.

![toolbox](/toolbox.png)

Note that the *dsConnections* item shown is used internally by the toolbar, and is not meant for use on its own.

After dropping on a form, you can add your own buttons to the toolbar appropriate for your app. Shown here is the default toolbar with no additional controls.

![toolbar](/toolbar.png)

The connection button on the far left displays this dialog for adding and managing connection strings:

![connections](/connections.png)

To avoid storing credentials in clear text, use **{login}** instead of the User ID and Password tokens. A login dialog will appear when you click Test All Connections. Saved credentials are encrypted with DPAPI in folder C:\Users\%profile%\AppData\Local\Adam O'Neil Software\Query Tools
