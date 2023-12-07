# ISA RO-Crate Profile

* Version: 0.1
* Permalink: _coming soon_
* Authors
  * Florian Wetzels - https://orcid.org/0000-0002-5526-7138
  * Lukas Weil - https://orcid.org/0000-0003-1945-6342
  * Sebastian Beier - https://orcid.org/0000-0002-2177-8781
  * Stuart Owen - https://orcid.org/0000-0003-2130-0865
  * Timo Muehlhaus - https://orcid.org/0000-0003-3925-6778


## Overview

A significant part of the previous work on this [RO-Crate](https://www.researchobject.org/ro-crate/) profile for [ISA](https://isa-tools.org/index.html) was produced as part of the [Annotated Research Context (ARC)](https://nfdi4plants.org/content/learn-more/annotated-research-context.html) project, through [arc-to-rocrate](https://github.com/nfdi4plants/arc-to-rocrate).

During the [ELIXIR Biohackathon 2023](https://biohackathon-europe.org/), as part of [Project 14: Enabling continuous RDM using Annotated Research Contexts with RO-Crate profiles for ISA](https://github.com/elixir-europe/biohackathon-projects-2023/tree/main/14), 
the profile was further fine tuned and some remaining unresolved mappings resolved.

The aim of the profile is to be able to fully represent [ISA-JSON](https://isa-specs.readthedocs.io/en/latest/isajson.html) as RO-Crate, fully capturing the metadata and files in a non-lossy form such that it
should be possible to convert between one to the other, in either direction, without loss of information.

The ISA RO-Crate has led to a few pending recommended changes to [Bioschemas](https://bioschemas.org/) types:

**[Dataset](https://bioschemas.org/profiles/Dataset/1.0-RELEASE)** - A new property _processSequence_ to describe how the Dataset was created.
  
**[LabProtocol](https://bioschemas.org/profiles/LabProtocol/0.7-DRAFT)** - Redefine it as a child of [HowTo](https://schema.org/HowTo), and make it clearer that it is intended to specifically describe the planned instructions.

**LabProcess (_new_)** - A suggested type and profile, as a child of [Action](https://schema.org/Action), to specifically describe the details outcomes of an executed LabProtocol. A working group
is being setup to define this as a new type.


_TODO: check property names on diagram edges_

```mermaid
flowchart TD

dataset[<h2>Investigation/Study/Assay=Dataset</h2>]

Process[<h2>LabProcess</h2>]

Protocol[<h2>Protocol=LabProtocol</h2>]

BioSample[<h2>Source/Sample/Material=Sample</h2>]

DataFile[<h2>Data=File</h2>]

ont[<h2>OntologyAnnotation=DefinedTerm</h2>]

prop[<h2>ParameterValue=PropertyValue</h2>]

dataset --hasPart--> dataset
dataset --hasPart----> DataFile
dataset --processSequence--> Process

Process --"result"---> DataFile
Process --"result"--> BioSample
Process --"object"--> BioSample
Process --executesLabProtocol--> Protocol
Process --parameterValue---> prop

BioSample --derivesFrom--> BioSample
BioSample --additionalProperty--> prop

Protocol --purpose---> ont
Protocol --labEquipment---> ont
Protocol --reagent---> ont

```

## Requirements

New properties that aren't currently part of the related type are shown in _italic_.

### Investigation

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'Dataset'|
|@id|MUST|Text or URL|Should be “./”, the investigation object represents the root data entity.|
|additionalType|MUST|Text or URL|‘Investigation’ or ontology term to identify it as an Investigation|
|headline|MUST|Text|A title of the investigation (e.g. a paper title).|
|creator|MUST|Person|The creator(s)/authors(s)/owner(s)/PI(s) of the investigation.|
|identifier|MUST|Text or URL|Identifying descriptor of the investigation (e.g. repository name).|
|description|SHOULD|Text|A description of the investigation (e.g. an abstract).|
|hasPart|SHOULD|Dataset (Study)|An Investigation object should contain other datasets representing the *studies* of the investigation.|
|dateCreated|SHOULD|DateTime|When the Investigation was created|
|dateModified|SHOULD|DateTime|When the Investigation was last modified|
|datePublished|COULD|DateTime|When the Investigation was published|
|citation|COULD|ScholarlyArticle|Publications corresponding with this investigation.|
|comment|COULD|Comment|Comment|
|mentions|COULD|DefinedTermSet|Ontologies referenced in this investigation.|

### Study

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'Dataset'|
|@id|MUST|Text or URL|Should be a subdirectory corresponding to this study.|
|additionalType|MUST|Text or URL|‘Study’ or ontology term to identify it as a Study|
|creator|MUST|Person|The performer of the study.|
|identifier|MUST|Text or URL|Identifying descriptor of the study.|
|headline|MUST|Text|A title of the study.|
|hasPart|SHOULD|Dataset (Assay) or File|Assays contained in this study or actual data files resulting from the process sequence.|
|_processSequence_|SHOULD|LabProcess|The experimental processes performed in this study.|
|description|SHOULD|Text|A short description of the study (e.g. an abstract).|
|dateCreated|SHOULD|DateTime|When the Study was created|
|dateModified|SHOULD|DateTime|When the Study was last modified|
|datePublished|COULD|DateTime|When the Study was published|
|citation|COULD|ScholarlyArticle|A publication corresponding to the study.|
|comment|COULD|Comment|Comment|

### Assay

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'Dataset'|
|@id|MUST|Text or URL|Should be a subdirectory corresponding to this assay.|
|additionalType|MUST|Text or URL|‘Assay’ or ontology term to identify it as an Assay|
|creator|MUST|Person|The performer of the experiments.|
|identifier|MUST|Text or URL|Identifying descriptor of the assay.|
|headline|MUST|Text|A title of the assay.|
|_processSequence_|MUST|LabProcess|The experimental processes performed in this assay.|
|measurementMethod|MUST|URL or DefinedType|Describes the type measurement e.g Complexomics or transcriptomics as an ontology term|
|measurementTechnique|MUST|URL or DefinedType|Describes the type of technology used to take the measurement, e.g mass spectrometry or deep sequencing|
|hasPart|SHOULD|File|The data files resulting from the process sequence|
|description|SHOULD|Text|A short description of the assay (e.g. an abstract)|
|variableMeasured|COULD|Text or PropertyValue|The target variable being measured E.g protein concentration|
|dateCreated|SHOULD|DateTime|When the Assay was created|
|dateModified|SHOULD|DateTime|When the Assay was last modified|
|citation|COULD|ScholarlyArticle|A publication corresponding to this assay.|
|comment|COULD|Comment|Comment|


### LabProcess (_new type_)

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'LabProcess'|
|@id|MUST|Text or URL|Could identify the process using the isa metadata filename and the protocol reference or process name.|
|name|MUST|Text| -|
|agent|MUST|Person|The performer|
|object|MUST|Sample or File|The input|
|result|MUST|Sample or File|The output|
|executesLabProtocol|SHOULD|LabProtocol|The protocol executed|
|parameterValue|SHOULD|PropertyValue|A parameter value of the experimental process, usually a key-value pair using ontology terms|
|endTime|SHOULD|DateTime||


### LabProtocol

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'LabProtocol'|
|@id|MUST|Text or URL|Could be the url pointing to the protocol resource.|
|url|MUST|URL|Pointer to protocol resources external to the ISA-Tab that can be accessed by their Uniform Resource Identifier (URI).|
|headline|SHOULD|Text|Main title of the LabProtocol.|
|purpose|SHOULD|URL or DefinedType|The protocol type as an ontology term|
|description|SHOULD|Text|A short description of the protocol (e.g. an abstract)|
|comment|COULD|Comment|Comment|
|version|COULD|Number of Text|An identifier for the version to ensure protocol tracking.|
|labEquipment|COULD|DefinedTerm or Text or URL|For LabProtocols it would be a laboratory equipment use by a person to follow one or more steps described in this LabProtocol.|
|reagent|COULD|BioChemEntity or DefinedTerm or Text or URL|Reagents used in the protocol.|
|software|COULD|SoftwareApplication|Software or tool used as part of the lab protocol to complete a part of it.|
|sameAs|COULD|URL|URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.|

### Sample

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'Sample'|
|@id|MUST|Text or URL|Could be the unique sample name.|
|name|MUST|Text|A name identifying the sample.|
|additionalProperty|SHOULD|PropertValue|characteristics or factors|
|_derivesFrom_|COULD|Sample|A source from which the sample is derived through processes.|

### Data

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'File' or 'MediaObject'|
|@id|MUST|File|Should be the path pointing to the file./
|name|MUST|Text or URL|The name of the file.|
|comment|COULD|Comment|Comment|
|encodingFormat|COULD|Text of URL|Media format as a MIME type|
|disambiguatingDescription|COULD|Text|The type of the data file (“Raw Data File", “Derived Data File" or "Image File").|

### PropertyValue

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'PropertyValue'|
|@id|MUST|Text or URL||
|name|MUST|Text|Key name|
|value|MUST|Text|Value text or number|
|propertyID|SHOULD|URL|Key ontology reference|
|unitCode|COULD|URL|Unit ontology reference|
|unitText|COULD|Text|Unit name|
|valueReference|COULD|URL|Value ontology reference|
|additionalType|COULD|Text|Can be used to describe if the value is a factor, characteristic or parameter.|

### Person

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'Person'|
|@id|MUST|Text or URL||
|givenName|MUST|Text||
|familyName|MUST|Text||
|email|SHOULD|Text||
|affiliation|SHOULD|Organization||
|jobTitle|SHOULD|DefinedTerm||
|additionalName|COULD|Text||
|address|COULD|PostalAddress or Text||
|telephone|COULD|Text||
|faxNumber|COULD|Text|
|disambiguatingDescription|COULD|Text|

### ScholarlyArticle

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Text|must be 'ScholarlyArticle'|
|@id|MUST|Text or URL||
|sameAs|MUST|URL|URL of a reference Web page that unambiguously indicates the item's identity.|
|headline|MUST|Text||
|author|SHOULD|Person||
|url|SHOULD|URL||
|creativeWorkStatus|COULD|DefinedTerm|The status of the publication in terms of its stage in a lifecycle.|
|disambiguatingDescription|COULD|Text|

## Example ro-crate-metadata.json

_TODO: simple example and a link to a more complete example_