| ISA term | schema term | Explanation |
|----------|-------------|-------------|
|Investigation|Dataset||
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
|Study|Dataset||
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
|Assay|Dataset||
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
|Process|[bioschemas.org/LabProcess](https://bioschemas.org/LabProcess)|
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
|Protocol|[bioschemas.org/LabProtocol](https://bioschemas.org/LabProtocol)|
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
|Sample|[bioschemas.org/Sample](https://bioschemas.org/Sample)||
|Source|[bioschemas.org/Sample](https://bioschemas.org/Sample)||
|@id|@id||
|name|name||
|characteristics|additionalProperty|Characteristics and factor values can be saved as `additionalProperties`. What they represent needs to be annotated.|
|factorValues|additionalProperty|Characteristics and factor values can be saved as `additionalProperties`. What they represent needs to be annotated.|
|derivesFrom|-|redundant information|
||
|Data|'File' or 'MediaObject'|
|@id|@id||
|name|name||
|comments|comment||
|-|encodingFormat|ARC-specific property|
|type|disambiguatingDescription||
||
|@type |[schema.org/Person](https://schema.org/Person)|
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
|Publication|[schema.org/ScholarlyArticle](https://schema.org/ScholarlyArticle)|
|@id|@id||
|title|headline||
|pubMedID|identifier|One or many identifiers for this article (DOI or PubMedID) can be encoded in identifier. Either as full URL or of type PropertyValue to indicate the kind of reference.|
|doi|identifier|One or many identifiers for this article (DOI or PubMedID) can be encoded in identifier. Either as full URL or of type PropertyValue to indicate the kind of reference.|
|authorList|author||
|status|creativeWorkStatus|
|comments|comment||
||
|Comment|Comment||
|@id|@id||
|name|name||
|value|text||
||
|OntologyAnnotation|DefinedTerm||
|annotationValue|name||
|termSource|inDefinedTermSet||
|termAccession|termCode||
|comments|disambiguatingDescription|Comment object in ISA has to be encoded as a string.|
||
|FactorValue|[schema.org/PropertyValue](https://schema.org/PropertyValue)|See details for properties below.|
|MaterialAttributeValue|[schema.org/PropertyValue](https://schema.org/PropertyValue)|See details for properties below.|
|ProcessParameterValue|[schema.org/PropertyValue](https://schema.org/PropertyValue)|See details for properties below.|
||
|OntologySourceReference|-|dropped type|
|Factor|-|dropped type|
|Material|-|dropped type|
|ProtocolParameter|-|dropped type|
|MaterialAttribute|-|dropped type|

The three types `MaterialAttributeValue`, `FactorValue` and `ProcessParameterValueValue` are all encoded as a [schema.org/PropertyValue](https://schema.org/PropertyValue).
All three represent a key-value-unit triple, with the key (`category`) essentially being an ontology term (of type `Factor`,`MaterialAttribute`,`ProtocolParameter`).
The key ontology term is always encoded as a URL and a name and therefore have to be resolved on export.
The value field is encoded in a straight-forward manner.
The unit is again an ontology term that has to be resolved into a URL and a name.

| ISA term | schema term | Explanation |
|----------|-------------|-------------|
|MaterialAttributeValue|[schema.org/PropertyValue](https://schema.org/PropertyValue)||
|FactorValue|[schema.org/PropertyValue](https://schema.org/PropertyValue)||
|ProcessParameterValue|[schema.org/PropertyValue](https://schema.org/PropertyValue)||
|@id|@id||
|category|name||
|value|value||
|category|propertyID||
|unit|unitCode||
|unit|unitText||
|value|valueReference||
|-|additionalType||Can be used to describe if the value is a factor, characteristic or parameter.|