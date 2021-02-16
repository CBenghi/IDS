# IDS Principles

Proposal for BuildingSmart's IDS standard for interoperable information requirements
in the context of construction projects.

Author: Jiri Hietanen, Datacubist

Date: 16th December 2020

## Two main sections

1. Selection: selecting a group of objects
  1.1. Antecedent
2. Requirements: assigning validation rules to the selected group of objects
  2.1 Consequent

## Selecting a group of objects

- Start with a limited set
  - But...
    - Not only object class
    - Not only classification reference

- Examples
  - All objects that are made from concrete must have a ‘Concrete class’ property
  - All IfcBeam objects with the PredefinedType HOLLOWCORE must have a ‘xxx’ property
    - Predefined type resolution order used by Statsbygg: Instance overrides type, user defined type is used if predefined type is ‘USERDEFINED’.
- Gravity is towards a full blown model query
  - This can be a lot of work for implementers

## Assigning validation

- Start with simple stuff
  - Concepts
    - Alphanumerical properties (Property set properties)
  - Validation types
    - Property exists/has a value
    - Text property values are from a list of allowed values (enumerations)
- Expand over time
  - Concepts
    - Classifications, materials, geo referencing, addresses etc.
  - Validation types
    - Patterns (wildcards, regular expressions…)
    - Measure values, dates etc.

## Alternative to inheritance

**With inheritance**: Interior Doors inherit requirements#1 from Doors and have both requirements#1 and requirements#2

- Doors → requirement N.1
  - Interior Doors → requirements N.2
  - Exterior Doors → requirements N.3

**Without inheritance**: Objects collect all requirements from all groups they belong to. If all objects in the Interior Doors group can also be found in the All Doors group, those objects have both requirements N.1 and requirements N.2

- All Doors → requirements N.1
- Interior Doors → requirements N.2
- Exterior Doors → requirements N.3
