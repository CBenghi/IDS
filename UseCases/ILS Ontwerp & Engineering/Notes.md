# ILS Ontwerp & Engineering

Information requirements are structured in a library, each represented by a card, which facilitates the
conversation between information providers and information consumers.

Presented by Jeffrey Truijens - JTruijens@vdndp.nl

## Information structure

Each element of information has the following properties:

### Domain

Examples:

- geometry,
- structure,
- components

This is used to group properties together, not sure for what purpose.

### Type

Possible values:

- g = generic, for all elements and across projects
- e = element specific, across the projects
- p = project specific

Use of this is unclear.

### Parameter (Name)

Examples:

- Naamgeving element (naming element)
  - IfcName, IfcType
- Codering - NL-SfB
  - IfcRelAssociatesClassification: IfcClassification

### Stage

Define at what stage of the project is required, by ticking the relevant stage in the project.
Phasing based on DNR STB 2014 supplemented with as-build and as-maintained:
(SO, VO, DO, TO, UO, AS-B)

### IFC data carrier (datadrager)

Examples:

- ObjectType
- IfcRelContainedInSpatialStructure: IfcBuildingStorey
- Longname (e) [for field e Ruimtenaam (Room name) ]
- ShortName (e) [for field e Ruimtenummer (Room number) ]
- [empty] (p) [e.g. for field Bouwnummer (construction number)]
- "IfcSpace; is gerelateerd aan IfcZone" (IfcSpace; is related to IfcZone)
- Pset_SpaceOccupancyRequirements:OccupancyNumberPeak

### Value (Invulwaarde)

Examples:

- IfcClass
- true/false
- aantal (number)

### Unit

Examples:

- stuks (Units)

## Examples

Structure
    "Bouwlaag (Building storey)"
    "g"
    "IfcRelContainedInSpatialStructure: IfcBuildingStorey"
    "vastleggen in separaat afsprakendocument (record in a separate agreement document)"

## Data Constraints

Looking at the **Checklist basic information delivery manual** document:

- there seems to be value constraints:
  - e.g. 3.3 BUILDING STOREYS AND NAMING:
- There might be need to x-ref classification and type
  - e.g. 3.4 CORRECT USE OF ENTITIES  Use the most appropriate type of BIM entity
- closed vocabulary check
  - e.g. 3.6 CLASSIFICATION SYSTEM Apply the existing classification system used in the relevant country
- Material classification
  - 3.7 OBJECTS WITH CORRECT MATERIALIZATION  Allocate objects with a material description (ifcMaterial).

## Notes

The USP of this case study is the existence of a (standardised?) set of cards to facilitate the
conversation on information requirements across stakeholders of a project.
Critically, this is needs to take into account the overall process and its breakdown in stages
and roles.

Relevant questions include:

- the ability of the project to steer the evolution of information management
across the various stages when stakeholders are added/removed to the team.
- the ability of professionals to define exact, testable and efficient information flows early in the project lifecycle.
