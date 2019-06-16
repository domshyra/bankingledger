# bankingledger
world’s greatest banking ledger

app created for AltSource


## To run this app ##

1. In the Package Manager Console run `Update-Database` (powershell) or in the console run `dotnet ef database update`
2. uncomment role code in Startup. This will add the Customer role to DB


### code in start up ###
This will add the Cutomer role to the DB. Delete that code once the app is run one time. 
            `//code for auto generating roles in the ASPNetRoles table
            //ApplicationRole customer = new ApplicationRole
            //{
            //    Name = "Customer"
            //};
            //IdentityResult roleResult = roleManager.CreateAsync(customer).Result;`

*note this will need to be deleted or commented out before the next star up.*
