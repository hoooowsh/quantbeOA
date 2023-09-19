# quantbeOA report
This is the report of this OA

## CI/CD ##
I don't have experience using implementing C# CI/CD pipelines, but I do have experience implementing NodeJS CI/CD pipelines. I will assume that the implementation for them will be very similar, because CI/CD is nothing but just auto testing and auto deployment. How it works in a software development cycle is test cases are added first for all functions and routes, then once a developer updated the routes or the functions and push to his branch on github, a set of tests will be run automatically, based on the result of all the test cases, developers can know if there is anything wrong with his code. Once he passes all the tests, then he is good for merging to main development branch, note here, it does not mean his code is bug free, passing all test cases is not bug free(This is mostly about CI). Once merge to development branch is done and his team completes a mailstone, then this development branch will be merged to production branch(there might be more steps before merging to production branch, depends on company needs), a script will run automatically to deploy the new changes, this is the CD part. 

### My experience with CI/CD with gitlab ###
I 
