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

| Property | Required | Description |
|----------|----------|-------------|
|@type |MUST|Dataset|
|@id|MUST|Should be “./”, the investigation object represents the root data entity.|
|additionalType|MUST|‘Investigation’ or ontology term to identify it as an Investigation|
|headline|MUST|Text - A title of the investigation (e.g. a paper title).|
|creator|MUST|Person - The creator(s)/authors(s)/owner(s)/PI(s) of the investigation.|
|identifier|MUST|Text or URL - Identifying descriptor of the investigation (e.g. repository name).|
|description|SHOULD|Text - A description of the investigation (e.g. an abstract).|
|hasPart|SHOULD|An Investigation object should contain other datasets representing the *studies* of the investigation.|
|dateCreated|SHOULD|DateTime|
|dateModified|SHOULD|DateTime|
|datePublished|COULD|DateTime|
|citation|COULD|ScholarlyArticle - Publications corresponding with this investigation.|
|comment|COULD|Comment|
|mentions|COULD|DefinedTermSet - Ontologies referenced in this investigation.|

### Study

| Property | Required | Description |
|----------|----------|-------------|
|@type |MUST|Dataset||
|@id|MUST|Should be a subdirectory corresponding to this study.|
|additionalType|MUST|‘Study’ or ontology term to identify it as a Study|
|creator|MUST|Person - The performer of the study.|
|identifier|MUST|Text or URL - Identifying descriptor of the study.|
|headline|MUST|Text - A title of the study.|
|hasPart|SHOULD|Dataset (Assays) and/or File - Assays contained in this study or actual data files resulting from the process sequence.|
|_processSequence_|SHOULD|LabProcess - The experimental processes performed in this study.|
|description|SHOULD|Text - A short description of the study (e.g. an abstract).|
|dateCreated|SHOULD|DateTime|
|dateModified|SHOULD|DateTime|
|datePublished|COULD|DateTime|
|citation|COULD|ScholarlyArticle - A publication corresponding to the study.|
|comment|COULD|Comment|

### Assay

| Property | Required | Description |
|----------|----------|-------------|
|@type |MUST|Dataset|
|@id|MUST|Should be a subdirectory corresponding to this assay.|
|additionalType|MUST|‘Assay’ or ontology term to identify it as an Assay|
|creator|MUST|Person - The performer of the experiments.|
|identifier|MUST|Text or URL - Identifying descriptor of the assay.|
|headline|MUST|Text - A title of the assay.|
|_processSequence_|MUST|LabProcess - The experimental processes performed in this assay.|
|measurementMethod|MUST|Describes the type measurement e.g Complexomics or transcriptomics as an ontology term - URL or DefinedType|
|measurementTechnique|MUST|Describes the type of technology used to take the measurement, e.g mass spectrometry or deep sequencing - URL or DefinedType|
|hasPart|SHOULD|The data files resulting from the process sequence - File.|
|description|SHOULD|A short description of the assay (e.g. an abstract) - Text|
|variableMeasured|COULD|The target variable being measured E.g protein concentration - Text or PropertyValue|
|dateCreated|COULD|DateTime|
|dateModified|COULD|DateTime|
|citation|COULD|ScholarlyArticle - A publication corresponding to this assay.|
|comment|COULD|Comment|


### LabProcess (_new type_)

| Property | Required | Description |
|----------|----------|-------------|
|@type |MUST|LabProcess|
|@id|MUST|Could identify the process using the isa metadata filename and the protocol reference or process name.|
|name|MUST|Text -|
|agent|MUST|The performer - Person|
|object|MUST|The input - Sample, File|
|result|MUST|The output - File, Sample|
|executesLabProtocol|SHOULD|The protocol executed - LabProtocol|
|parameterValue|SHOULD|A parameter value of the experimental process, usually a key-value pair using ontology terms - PropertyValue|
|endTime|SHOULD|DateTime|


### LabProtocol

| Property | Required | Description |
|----------|----------|-------------|
|@type |MUST|LabProtocol|
|@id|MUST|Could be the url pointing to the protocol resource.|
|url|MUST|Pointer to protocol resources external to the ISA-Tab that can be accessed by their Uniform Resource Identifier (URI).|
|headline|SHOULD|Main title of the LabProtocol. - Text|
|purpose|SHOULD|The protocol type as an ontology term - URL or DefinedType|
|description|SHOULD|A short description of the protocol (e.g. an abstract)|
|comment|COULD|Comment|
|version|COULD|An identifier for the version to ensure protocol tracking.|
|labEquipment|COULD|For LabProtocols it would be a laboratory equipment use by a person to follow one or more steps described in this LabProtocol.|
|reagent|COULD|Reagents used in the protocol.|
|software|COULD|Software or tool used as part of the lab protocol to complete a part of it.|
|sameAs|COULD|URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.|

## Example ro-crate-metadata.json