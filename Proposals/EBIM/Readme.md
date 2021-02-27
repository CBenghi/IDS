# Capturing the Information Delivery Specification (IDS) in the Autodesk EBIM Tool

Author: Peter Muigg

Date: 27th January 2021

The Autodesk EBIM Tool (European BIM Standards Tool) stores the information requirements in an XML file, the structure of the information is stored in an “xsd” file as described in the following.

## Structure of the IDS Information

What is captured basically is the representation of a data structure using a relational database schema which described in the .xsd File “MetaData.xsd”. The structure used closely assembles the structure of the bSDD (buildingSMART Data Dictonary). In the bSDD, everything is a “Concept”, this is the base class of:

Name in bSDD | Table Name | Description
------- | ------- | -------
SUBJECT  | Subjects | Building Elements and Materials
PROPERTY | Properties |  
MEASURE | Measures | Assigned to properties
VALUE |  | Values |  | the allowed values (also referred to as “enumerations”) for a prop
UNIT |  | Units |  | Assigned to measures

A SUBJECT represents a building element or a material, a PROPERTY is, of course, a property. A MEASURE is describing how a property has to be specified by means of its unit, data type and it can also be specified which individual VALUES a property may have by specifying these possible values in a list.

The information for all these “concepts” stored consists of its name in three languages: Local, English and IFC (this is following the bSDD approach by using IFC as an additional language of classification) and the description for a local language (which, of course, can be any language) and English (Desciption_Loc, Desciption_Int). The “bSDD_Guid” is also stored for any concept, but the actual identifier is the “freeBIM_Guid”, and there is also a “ShortName”. The tables for the different types of concepts have additional information dependent of its type, for example the “Subects” Table also contains a pointer to a parent-subject to represent the tree structure in IFC.

The bSDD also allows to use “collections”, but in the EBIM-Structure only one type of collection is dealt with, the Property-Set (PSet), which is a group of properties and the data-type that describes how a piece of information is stored in a computer (as a double, integer, boolean or string value). So the list above is extended by the tables:

Table Name | Description
-----------|-------------
Lists |  Contains the “Value-Lists” referenced by measures
DataTypes | Contains the “Data-Types” referenced by measures
PropertySets | Names of the PSets used
Phases |  This is to specify the “Phase” when a property is to be provided
Project_Types | This is to define use cases or project-types

All the tables mentioned above are “connected” with each other using relations which are also stored in tables, the relations stored are these tables:

Table Name | Description
-----------|-------------
Assigns_Properties | Connection between subjects and Properties also including the Phase
Assigns_Measures | Connection between properties and measures
Assigns_Lists | Assigns lists to measures
Assigns_Values | Assigns values to lists
AssignsPropertiesToSets | Defines the Property-Sets
Prop_Comp_Assignment | Used for the definition of use cases

As a measure may only have one data-type and unit, the references to units and data-types is stored in a measure directly.

## Example file

In the EBIM Tool, the IDS is stored in a file called “freeBimXML.xml”, the name comes from a research project funded by the government of Tyrol to develop the Properties-Server for the Austrian Standards Institute (ASI) and contains example content.

## Using the “XSD” File

It should be possible to use an `xsd` file by any development environment. If you are using Visual Studio, the procedure simply is to select a project and use the feature `Add` -> `Existing Element` -> `Data Source` and then select the File `MetaData.xsd`. When you select this file, the table structure should be displayed. You can then create an instance of the class `MetaData` created and read an XML File representing this structure and use the tables as `DataTable` instances in Visual Studio.
