# Todo-Backend

[Todo-Backend](https://www.todobackend.com/) defines a simple REST API to showcase backend tech stacks.

This sample implements the specs using [Firestorm](https://github.com/connellw/Firestorm). You can run the sample locally and run the specs against it by opening [the test page](https://www.todobackend.com/specs/index.html?http://localhost:5000/todos/) targeting http://localhost:5000/todos/.

In order to meet the specs, the DELETE strategy is configured to clear a collection and `ResourceOnSuccessfulCommand` is set to true.

The sample uses an in-memory data store and an `AutoIncrement` helper to provide IDs.