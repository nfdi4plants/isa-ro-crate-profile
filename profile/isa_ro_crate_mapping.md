## Mapping

This is the mapping between ISA-json types defined in https://isa-specs.readthedocs.io/en/latest/isajson.html and [`schema.org`](https://schema.org/)-types used by the  isa-ro-crate-profile defined in https://github.com/nfdi4plants/isa-ro-crate-profile/blob/main/profile/isa_ro_crate.md .

| ISA term | schema term | Explanation |
|----------|-------------|-------------|
|[Investigation](https://isa-specs.readthedocs.io/en/latest/isajson.html#investigation-schema-json)|[Dataset](https://schema.org/Dataset)||
|@id|@id||
|-|additionalType|for distinction from Study and Assay|
|fileName|url||
|title|headline||
|people|creator||
|identifier|identifier||
|description|description||
|studies|hasPart||
|submissionDate|dateCreated||
|-|dateModified||
|publicReleaseDate|datePublished||
|publications|citation||
|comments|comment||
|onntologySourceReferences|mentions||
||
|[Study](https://isa-specs.readthedocs.io/en/latest/isajson.html#study-schema-json)|[Dataset](https://schema.org/Dataset)||
|@id|@id||
|-|additionalType|for distinction from Investigation and Assay|
|fileName|url||
|people|creator||
|identifier|identifier||
|title|headline||
|assays|hasPart||
|processSequence|about||
|description|description||
|submissionDate|dateCreated||
|-|dateModified||
|publicReleaseDate|datePublished||
|publications|citation||
|comments|comment||
|studyDesignDescriptor|-|redundant information|
|protocols|-|redundant information|
|materials|-|redundant information|
|factors|-|redundant information|
|characteristicCategories|-|redundant information|
|unitCategories|-|redundant information|
||
|[Assay](https://isa-specs.readthedocs.io/en/latest/isajson.html#assay-schema-json)|[Dataset](https://schema.org/Dataset)||
|@id|@id||
|-|additionalType|for distinction from Investigation and Study|
|-|identifier||
|processSequence|about||
|-|creator|ARC-specific property|
|technologyType|measurementMethod||
|technologyPlatform|measurementTechnique||
|dataFiles|hasPart||
|measurementType|variableMeasured||
|comments|comment||
|fileName|url||
||
|[Process](https://isa-specs.readthedocs.io/en/latest/isajson.html#process-schema-json)|[bioschemas.org/LabProcess](https://bioschemas.org/LabProcess)|
|@id|@id||
|name|name||
|performer|agent||
|inputs|object||
|outputs|result||
|executesProtocol|executesLabProtocol||
|parameterValues|parameterValue||
|date|endTime||
|previousProcess|-|redundant information|
|nextProcess|-|redundant information|
|comments|disambiguatingDescription||
||
|[Protocol](https://isa-specs.readthedocs.io/en/latest/isajson.html#protocol-schema-json)|[bioschemas.org/LabProtocol](https://bioschemas.org/LabProtocol)|
|@id|@id||
|name|name||
|protocolType|intendedUse||
|description|description||
|uri|url||
|-|comment|ARC-specific property|
|version|version||
|components|labEquipment|Components can be saved as `labEquipment`, `reagent`, or `computationalTool`, with `labEquipment` being the default.|
|components|reagent|Components can be saved as `labEquipment`, `reagent`, or `computationalTool`, with `labEquipment` being the default.|
|components|computationalTool|Components can be saved as `labEquipment`, `reagent`, or `computationalTool`, with `labEquipment` being the default.|
|parameters|-|redundant information|
||
|[Sample](https://isa-specs.readthedocs.io/en/latest/isajson.html#sample-schema-json)|[bioschemas.org/Sample](https://bioschemas.org/Sample)||
|[Source](https://isa-specs.readthedocs.io/en/latest/isajson.html#source-schema-json)|[bioschemas.org/Sample](https://bioschemas.org/Sample)||
|@id|@id||
|name|name||
|characteristics|additionalProperty|Characteristics and factor values can be saved as `additionalProperties`. What they represent needs to be annotated.|
|factorValues|additionalProperty|Characteristics and factor values can be saved as `additionalProperties`. What they represent needs to be annotated.|
|derivesFrom|-|redundant information|
||
|[Data](https://isa-specs.readthedocs.io/en/latest/isajson.html#data-schema-json)|'File' or '[MediaObject](https://schema.org/MediaObject)'|
|@id|@id||
|name|name||
|comments|comment||
|-|encodingFormat|ARC-specific property|
|type|disambiguatingDescription||
||
|[Person](https://isa-specs.readthedocs.io/en/latest/isajson.html#person-schema-json)|[schema.org/Person](https://schema.org/Person)|
|@id|@id||
|firstName|givenName||
|lastName|familyName||
|email|email||
|-|identifier|Can be used for identifiers stored in comment, e.g. an orcid.|
|affiliation|affiliation|The affilitation strin in ISA is converted to an Oranization object.|
|roles|jobTitle||
|midInitials|additionalName||
|address|address||
|phone|telephone||
|fax|faxNumber||
|comments|disambiguatingDescription|Comment object in ISA has to be encoded as a string.|
||
|[Publication](https://isa-specs.readthedocs.io/en/latest/isajson.html#publication-schema-json)|[schema.org/ScholarlyArticle](https://schema.org/ScholarlyArticle)|
|@id|@id||
|title|headline||
|pubMedID|identifier|One or many identifiers for this article (DOI or PubMedID) can be encoded in identifier. Either as full URL or of type PropertyValue to indicate the kind of reference.|
|doi|identifier|One or many identifiers for this article (DOI or PubMedID) can be encoded in identifier. Either as full URL or of type PropertyValue to indicate the kind of reference.|
|authorList|author||
|status|creativeWorkStatus|
|comments|comment||
||
|[Comment](https://isa-specs.readthedocs.io/en/latest/isajson.html#comment-schema-json)|[Comment](https://schema.org/Comment)||
|@id|@id||
|name|name||
|value|text||
||
|[OntologyAnnotation](https://isa-specs.readthedocs.io/en/latest/isajson.html#ontology-annotation-schema-json)|[DefinedTerm](https://schema.org/DefinedTerm)||
|annotationValue|name||
|termSource|inDefinedTermSet||
|termAccession|termCode||
|comments|disambiguatingDescription|Comment object in ISA has to be encoded as a string.|
||
|[FactorValue](https://isa-specs.readthedocs.io/en/latest/isajson.html#factor-value-schema-json)|[schema.org/PropertyValue](https://schema.org/PropertyValue)|See details for properties [below](#key-value-unit-triples).|
|[MaterialAttributeValue](https://isa-specs.readthedocs.io/en/latest/isajson.html#material-attribute-value-schema-json)|[schema.org/PropertyValue](https://schema.org/PropertyValue)|See details for properties [below](#key-value-unit-triples).|
|[ProcessParameterValue](https://isa-specs.readthedocs.io/en/latest/isajson.html#process-parameter-value-schema-json)|[schema.org/PropertyValue](https://schema.org/PropertyValue)|See details for properties [below](#key-value-unit-triples).|
||
|[OntologySourceReference](https://isa-specs.readthedocs.io/en/latest/isajson.html#ontology-source-reference-schema-json)|-|dropped type|
|[Factor](https://isa-specs.readthedocs.io/en/latest/isajson.html#factor-schema-json)|-|dropped type|
|[Material](https://isa-specs.readthedocs.io/en/latest/isajson.html#material-schema-json)|-|dropped type|
|[ProtocolParameter](https://isa-specs.readthedocs.io/en/latest/isajson.html#protocol-parameter-schema-json)|-|dropped type|
|[MaterialAttribute](https://isa-specs.readthedocs.io/en/latest/isajson.html#material-attribute-schema-json)|-|dropped type|

### Key-Value-Unit Triples

The three types `MaterialAttributeValue`, `FactorValue` and `ProcessParameterValueValue` are all encoded as a [schema.org/PropertyValue](https://schema.org/PropertyValue).
All three represent a key-value-unit triple, with the key (`category`) essentially being an ontology term (of type `Factor`,`MaterialAttribute`,`ProtocolParameter`).
The key ontology term is always encoded as a URL and a name and therefore have to be resolved on export.
The value field is encoded in a straight-forward manner.
The unit is again an ontology term that has to be resolved into a URL and a name.

| ISA term | schema term | Explanation |
|----------|-------------|-------------|
|[MaterialAttributeValue](https://isa-specs.readthedocs.io/en/latest/isajson.html#material-attribute-value-schema-json)|[schema.org/PropertyValue](https://schema.org/PropertyValue)||
|[FactorValue](https://isa-specs.readthedocs.io/en/latest/isajson.html#factor-value-schema-json)|[schema.org/PropertyValue](https://schema.org/PropertyValue)||
|[ProcessParameterValue](https://isa-specs.readthedocs.io/en/latest/isajson.html#process-parameter-value-schema-json)|[schema.org/PropertyValue](https://schema.org/PropertyValue)||
|@id|@id||
|category|name|Name of the category.|
|value|value|Value as number or string.|
|category|propertyID|Ontology URL of the category.|
|unit|unitCode|Ontology URL of the unit.|
|unit|unitText|Name of the unit.|
|value|valueReference|Ontology URL or ontology term objetc of the value.|
|-|additionalType||Can be used to describe if the value is a factor, characteristic or parameter.|