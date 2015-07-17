# SignalRAndWCF
SignalR MVC project with two-way communication to a WCF service

This is an MVC hosted SignalR application that has two-way communication to a WCF service to demo how to update a client when running a long-running task in the WCF service.

There are 4 users:
 - test@test.com
 - test2@test.com
 - test3@test.com
 - test4@test.com

The password for all users is "Testing123!" (without quotes).

There is a "SpecialRole" that test3 and test4 belong to.


The listener controller determines if the user that started the long running task is still online, and if so, delivers the messages to that user.  If not, it delivers the messages to all users belonging to the "SpecialRole".


You can test this by using two different browsers (Chrome and Firefox, IE if you must...).  
