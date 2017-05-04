# ConnectionUI

Standard connection toolbar for WinForms apps that need a SQL Server connection in a dropdown. Nuget package **AoConnnectionUI**.

After installing the package, right click on the VS toolbox and Add Items from /bin/ConnectionUI.dll. This will add **DbConnection** toolbar to the toolbox:

![toolbar](/toolbar.png)

The connection button on the far left displays this dialog for adding and managing connection strings:

![connections](/connections.png)

To avoid storing credentials in clear text, use **{login}** instead of the User ID and Password tokens. A login dialog will appear when you click Test All Connections. Saved credentials are encrypted with DPAPI in folder C:\Users\%profile%\AppData\Local\Adam O'Neil Software\Query Tools
