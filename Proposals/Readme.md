# IDS Schema evaluation criteria

## Identification of relevant model parts

Schema should be able to express various forms of model break down

- F1 - By IfcType
- F2 - By property with specific value
  - F2.1 - Value of single property by PropertySet, PropertyName and PropertyValue
- F3: - Classification
  - F3.1 - ClassificationName and ReferenceValue
- F4: Express multiple breakdown criteria.
  - F4.1 - List of criteria (flat AND list)
  - F4.2 - Articulated criteria (hierarchical boolean logic)

## Capabilities for model testing

Schema should be able to express the following requirements:

- T1 Properties
  - T1.0 - Identification of IfcPropertySingleValue via:
    - T1.0.1 - name of IfcPropertySetDefinitionSelect, PropertyName
    - T1.0.2 **(Optional)** - PropertySetName, PropertyName, PropertyValueType
  - T1.1 - Is not null
  - T1.2 **(Optional)** - Expected values (list)
  - T1.3 **(Optional)** - Invalid values (list)
  - T1.4 **(TBD)** - Allow association via type (defaults to true)
- T2 Quantities
  - T2.0 - Identification via:
    - T2.0.1 - PropertySetName, QuantityName
    - T2.0.2 **(Optional)** - PropertySetName, QuantityName, QuantityValueType
    - T2.0.4 **(Optional)** - Unit of measure
  - T2.1 - Is not null
  - T2.2 **(Optional)** - Expected values (list)
  - T2.3 **(Optional)** - Range (min..max)
  - T2.4 **(Optional)** - Multiple ranges ((min..max), (min..max))
- T3 Classification
  - T3.0 - Identification via:
    - T3.0.1 - ClassificationName
  - T3.1 - Is not null
  - T3.2 **(Optional)** - Value is constrained
  - T3.3 **(Optional)** - Expected values (list)
- T4 Material
  - T4.1 - Is not null
  - T4.2 - HasName (need to determine behaviors for various subclasses of IfcMaterialDefinition).
  - T4.3 **(Optional)** - Name has expected values (list)
- T5 Documents **(Optional)**
  - T5.0 Identification of IfcDocumentReference via IfcRelAssociatesDocument, filtered by
    - T5.0.1 - Attribute: Identification
    - T5.0.2 - Attribute: Name
    - T5.0.2 - Attributes: Identification and Name
  - T5.1 - Is not null
  - T5.2 - Required Attributes (Location, ReferencedDocument, Description)
- T6 Attribute **(TBD)**
  - T6.0 Identification of attribute
    - T6.0.1 - filter on class and name
    - T6.0.2 - filter on name
  - T6.1 - Is not null
  - T6.2 - Is of specific type
  - T6.2 - Is of specific type, includes subtypes

## Strategic benefits

- S1 - Case for schema longevity
  - S1.1 - Ease of feature expansion
  - S1.2 - Fitness for AEC processes
  - S1.3 - Fitness for IT technologies
  - S1.4 - Fitness for innovative commercial services
  - S1.5 - (more to add)
- S2 - Compatibility with relevant standards
- S3 - Extra workflows permitted by the schema
  - S3.1 - Allow to perform model stripping
  - S3.2 - (more to add)
