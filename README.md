# DataTablesNet.Module
A module to integrate with DataTables.net server side
The module provides a DTRequest object, which parses the posted form values by the DataTables.net library, into a strongly typed object. The object can then be used to filter records as required.
Once the records have been filtered as required, the results to be returned can then be sent back using the wrapper DTResponse class, which provides the data to the DataTables.net library in the expected 
format.

The project DataTablesNet.Module provides the request and response classes.
The DataTablesNet.Api project is an Api displaying the implementation of an endpoint which the DataTables.net library will call to request for data.
The DataTablesNet.Web project is a sample implemetation of how to make the call to the Api which would provide the data for the DataTables.net.
