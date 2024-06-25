| ISA term | schema term | Explanation |
|----------|-------------|-------------|
|Investigation|Dataset|for distinction from Study and Assay|
|@id|@id||
|-|additionalType||
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
|processSequence|about|
|-|creator|
|technologyType|measurementMethod||
|technologyPlatform|measurementTechnique||
|dataFiles|hasPart||
|measurementType|variableMeasured||
|comments|comment||
|fileName|url||