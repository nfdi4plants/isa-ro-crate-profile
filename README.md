# ISA RO-Crate Profile

* Version: 0.1
* Permalink: _coming soon_
* Authors
  * Florian
  * Lukas  
  * Timo
  * Stuart
  * Sebastian  
    

## Overview

## Requirements

New properties that aren't currently part of the related type are shown in _italic_.

### Investigation

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Dataset||
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
|comment|COULD|Text|Comment|
|mentions|COULD|DefinedTermSet|Ontologies referenced in this investigation.|

### Study

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Dataset||
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
|comment|COULD|Text|Comment|

### Assay

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|Dataset||
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
|comment|COULD|Text|Comment|


### LabProcess (_new type_)

| Property | Required | Expected Type | Description |
|----------|----------|---------------|-------------|
|@type |MUST|LabProcess||
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
|@type |MUST|LabProtocol||
|@id|MUST|Text or URL|Could be the url pointing to the protocol resource.|
|url|MUST|URL|Pointer to protocol resources external to the ISA-Tab that can be accessed by their Uniform Resource Identifier (URI).|
|headline|SHOULD|Text|Main title of the LabProtocol.|
|purpose|SHOULD|URL or DefinedType|The protocol type as an ontology term|
|description|SHOULD|Text|A short description of the protocol (e.g. an abstract)|
|comment|COULD|Text|Comment|
|version|COULD|Number of Text|An identifier for the version to ensure protocol tracking.|
|labEquipment|COULD|DefinedTerm or Text or URL|For LabProtocols it would be a laboratory equipment use by a person to follow one or more steps described in this LabProtocol.|
|reagent|COULD|BioChemEntity or DefinedTerm or Text or URL|Reagents used in the protocol.|
|software|COULD|SoftwareApplication|Software or tool used as part of the lab protocol to complete a part of it.|
|sameAs|COULD|URL|URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.|

## Example ro-crate-metadata.json