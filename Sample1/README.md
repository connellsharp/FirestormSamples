# Sample 1

This sample shows a blog or forum model with an `IEventPublisher` instance injected into the Stems.

**EntityFramework** is configured in a separate project within the same solution. The **Domain|** project contains models and messages used by the Stems.

The Functional Tests demonstrate adding new posts, liking a post and counting the number of likes.