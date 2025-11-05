// Script for creation of the profile crate

#r "nuget: ROCratePCC"

open ARCtrl.ROCrate
open ARCtrl.Json
open ROCratePCC

let types = ResizeArray [
    UsedType(iri = "https://schema.org/Dataset", name = "Dataset");
    UsedType(iri = "https://bioschemas.org/types/LabProcess/0.1-DRAFT", name = "LabProcess");
    UsedType(iri = "https://bioschemas.org/types/LabProtocol/0.5-DRAFT", name = "LabProtocol"); 
    UsedType(iri = "https://schema.org/PropertyValue", name = "PropertyValue");
    UsedType(iri = "https://schema.org/DefinedTerm", name = "DefinedTerm");
    UsedType(iri = "https://schema.org/Person", name = "Person");
    UsedType(iri = "https://schema.org/ScholarlyArticle", name = "ScholarlyArticle");
    UsedType(iri = "https://schema.org/Comment", name = "Comment");
    UsedType(iri = "https://schema.org/MediaObject", name = "MediaObject");
    UsedType(iri = "https://bioschemas.org/types/Sample/0.3-DRAFT", name = "Sample");
    UsedType(iri = "https://schema.org/Organization", name = "Organization");
]

let authors = [
    Author(orcid = "0000-0002-5526-71389", name = "Florian Wetzels");
    Author(orcid = "0000-0003-1945-6342", name = "Heinrich Lukas Weil");
    Author(orcid = "0000-0002-2198-5262", name = "Kevin Schneider");
    Author(orcid = "0000-0003-2130-0865", name = "Stuart Owen");
]

let version = "1.0.0-draft.2"

let id = $"https://github.com/nfdi4plants/isa-ro-crate-profile/tree/{version}/profile"

let name = "ISA RO-Crate Profile"

let license = License(
        iri = "https://mit-license.org/",
        name = "MIT License"
    )

let description = "An RO-Crate profile for representing ISA (Investigation, Study, and Assay) in Research Object Crates (RO-Crates)."

let specifications = ResizeArray[
    TextualResource(
        name = "ISA RO-Crate Profile description",
        filePath = "isa_ro_crate.md",
        encodingFormat = "text/markdown",
        rootDataEntityId = id
    )
]

let guidances = ResizeArray[
    TextualResource(
        name = "ISA RO-Crate ISA Tab/Json mapping guidance",
        filePath = "isa_ro_crate_mapping.md",
        encodingFormat = "text/markdown",
        rootDataEntityId = id
    )
    TextualResource(
        name = "ISA RO-Crate Annotation Modelling guidance",
        filePath = "https://arc-rdm.org/details/documentation-principle/",
        encodingFormat = "text/html",
        rootDataEntityId = id
    )
]

let examples = ResizeArray[
    TextualResource(
        name = "ISA RO-Crate Example",
        filePath = "https://git.nfdi4plants.org/venn/Ru_ChlamyHeatstress/-/package_files/35699/download",
        encodingFormat = "application/json",
        rootDataEntityId = id
    )
]

let resourceDescriptors = ResizeArray [
    Specification(specifications) :> ResourceDescriptor
    Guidance(guidances) :> ResourceDescriptor
    Example(examples) :> ResourceDescriptor
]

let rootEntity = 
    RootDataEntity(
        id = id,
        name = name,
        description = description,
        license = license,
        usedTypes = types,
        resourceDescriptors = resourceDescriptors,
        authors = ResizeArray authors
    )

let profile = 
    Profile(
        rootEntity,
        license = license
    )

let string = profile.ToROCrateJsonString(spaces = 2)

System.IO.File.WriteAllText("profile/ro-crate-metadata.json", string)
