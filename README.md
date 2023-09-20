# quantbeOA report
This is the report of this OA.

## CI/CD ##
I don't have experience using implementing C# CI/CD pipelines, but I do have experience implementing NodeJS CI/CD pipelines on Gitlab. I will assume that the implementation for them will be very similar, because CI/CD is nothing but just auto testing and auto deployment. How it works in a software development cycle is test cases are added first for all functions and routes, then once a developer updated the routes or the functions and push to his branch on github, a set of tests will be run automatically, based on the result of all the test cases, developers can know if there is anything wrong with his code. Once he passes all the tests, then he is good for merging to main development branch, note here, it does not mean his code is bug free, passing all test cases is not bug free(This is mostly about CI). Once merge to development branch is done and his team completes a mailstone, then this development branch will be merged to production branch(there might be more steps before merging to production branch, depends on company needs), a script will run automatically to deploy the new changes, this is the CD part. 

### My experience with CI/CD with gitlab ###
I will mainly talk about my experience in gitlab CI/CD. So first, Gitlab needs users to register a device as runner on Gitlab, I personally won't choose shared Runner because it is shared among all users and it can be extremly slow. For private runner, user will need a device to go through all the config steps and register that device as a Runner, then set up the running environment. Once it's done, developer needs to upload some env vars in gitlab and implement the CI/CD script for Gitlab CI/CD. Now the user needs to run the runner in that particular machine, then everytime a push happens, that machine will excute the test and it will show the result in gitlab. 

## Some thoughts ##
I'm not sure the use case of this encoded url, but I assume the purpose of encoding the original url is to hide some important info. 
1. Salt and Key are hard coded and Salt is not random
2. More Error cases can be added, maybe a global error handler can be implemented to formulize the whole codebase
3. Maybe add input validation and output encoding, add authentication so only eligible person has access to this route. Or maybe do not return the encoded url to frontend, directly making a API call to the encoded url from this server(this should be based on what specific use case for this route)
4. Turn this encoding functionalities to a micro service
5. Adding more validation middleware for incoming requests