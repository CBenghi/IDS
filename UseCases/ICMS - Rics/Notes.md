# International Construction Measurement Standards (ICMS)

Presented by Andrew Knight - aknight@rics.org

ICMS is a high-level reporting standard for buildings and infrastructure, for cost benchmarking.
It needs summary asset, site, contract and cost data for like-for-like comparisons.

The aim is to link (and extract?) cost-related information from IFC models.

## Cost and model data

Relevant IFC entities identified are: Building, Storey/Floor, Space, Zone, Site, Project.

Computing some of the information mentioned could requiure aggregation: e.g. count of stories, rooms, rooms (divided by type?).

In the presentation it was assumed that some of the metrics could be present in models, but there was no clear indication
of whether they would use the IDS to identify if any interesting information is available, rather than partaking
in the definition of the requirement.
Is ICMS willing to influence the definition of the IDS, e.g. by defining their own IDS ADD-ON REQS?

If there's any cost information in the models it could be identified by classification (e.g. Uniclass).
Other cost information might be available inside the common data environment in other sources.

## Features

- If RICS defines a standard ICMS requirement it could be interesting to have the feature to make the format composable, so that
(at any stage) an existing IDS could be enriched by IMPORTING the standard ICMS template of requirements.
- There might be the need of future extension around geoemtric support: e.g. extracting and eggregating model dimensions.
