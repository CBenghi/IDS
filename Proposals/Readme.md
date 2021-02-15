# IDS Schema functions

Schema should be able to define the following requirements:

## Identification of model subsets by combination of the following rules

- S1: By IfcType
- S2: By property with specific value
  - S2.1 Value of single property by ProperySet, PropertyName and PropertyValue
- S3: By Classification
  - S3.1 ClassificationName and ReferenceValue

## Tests for each entity in the identified subset

- T1 Properties
  - T1.0 - Identification of IfcPropertySingleValue via:
    - T1.0.1 - PropertySetName, PropertyName
    - T1.0.2 (Optional) - PropertySetName, PropertyName, PropertyValueType
  - T1.1 - Is not null
  - T1.2 (Optional) - Expected values (list)
  - T1.3 (Optional) - Invalid values (list)
- T2 Quantities
  - T2.0 - Identification via:
    - T2.0.1 - PropertySetName, QuantityName
    - T2.0.2 (Optional) - PropertySetName, QuantityName, QuantityValueType
    - T2.0.4 (Optional) - Unit of measure
  - T2.1 - Is not null
  - T2.2 (Optional) - Expected values (list)
  - T2.3 (Optional) - Range (min..max)
  - T2.4 (Optional) - Multiple ranges ((min..max), (min..max))
- T3 Classification
  - T3.0 - Identification via:
    - T3.0.1 - ClassificationName
  - T3.1 - Is not null
  - T3.2 (Optional) - Value is constrained
  - T3.3 (Optional) - Expected values (list)
- T4 Material
  - T4.1 - Is not null
  - T4.2 - HasName (need to determine behaviours for various subclasses of IfcMaterialDefinition).
  - T4.3 (Optional) - Name has expected values (list)
- T5 Documents (Optional)
  - T5.0 Identification of  by
    - T5.0.1 - Attribute: Identification
    - T5.0.2 - Attribute: Name
    - T5.0.2 - Attributes: Identification and Name
  - T5.1 - Is not null
  - T5.2 - Required Attributes (Location, ReferencedDocument, Description)
