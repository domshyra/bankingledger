# bankingledger
world’s greatest banking ledger

app created for AltSource


## To run this app ##

1. In the Package Manager Console runt `Update-Database`
2. uncomment role code in Startup. 


### code in start up ###
This will add the Cutomer role to the DB. Delete that code once the app is run one time. 
            `//code for auto generating roles in the ASPNetRoles table
            //ApplicationRole customer = new ApplicationRole
            //{
            //    Name = "Customer"
            //};
            //IdentityResult roleResult = roleManager.CreateAsync(customer).Result;`

*note this will need to be deleted or uncoomment and the next star up. *
