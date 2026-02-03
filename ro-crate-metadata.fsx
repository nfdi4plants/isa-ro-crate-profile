// Script for creation of the profile crate

#r "nuget: ROCratePCC"

open ARCtrl.ROCrate
open ARCtrl.Json
open ROCratePCC

let types = ResizeArray [
    UsedType(iri = "https://schema.org/Dataset", name = "Dataset");
    UsedType(iri = "https://bioschemas.org/types/LabProcess/0.1-DRAFT", name = "LabProcess", termCode = "LabProcess");
    UsedType(iri = "https://bioschemas.org/types/LabProtocol/0.5-DRAFT", name = "LabProtocol", termCode = "LabProtocol"); 
    UsedType(iri = "https://schema.org/PropertyValue", name = "PropertyValue");
    UsedType(iri = "https://schema.org/DefinedTerm", name = "DefinedTerm");
    UsedType(iri = "https://schema.org/Person", name = "Person");
    UsedType(iri = "https://schema.org/ScholarlyArticle", name = "ScholarlyArticle");
    UsedType(iri = "https://schema.org/Comment", name = "Comment");
    UsedType(iri = "https://schema.org/MediaObject", name = "MediaObject");
    UsedType(iri = "https://bioschemas.org/types/Sample/0.3-DRAFT", name = "Sample", termCode = "Sample");
    UsedType(iri = "https://schema.org/Organization", name = "Organization");
]
let rptu = Organization(
    name = "RPTU Kaiserslautern-Landau",
    url = "https://ror.org/01qrts582"
)

let uom = Organization(
    name = "The University of Manchester",
    url = "https://ror.org/027m9bs27"
)

let authors = [
    Author(orcid = "0000-0002-5526-71389", name = "Florian Wetzels", affiliation = rptu);
    Author(orcid = "0000-0003-1945-6342", name = "Heinrich Lukas Weil", affiliation = rptu);
    Author(orcid = "0000-0002-2198-5262", name = "Kevin Schneider", affiliation = rptu);
    Author(orcid = "0000-0003-2130-0865", name = "Stuart Owen", affiliation = uom);
]

let publisher = Organization(
    name = "DataPLANT",
    url = "https://nfdi4plants.de/"
)
publisher.SetProperty("http://schema.org/alternateName", "NFDI4Plants")

let version = "1.0.0-draft.2"

let id = $"https://github.com/nfdi4plants/isa-ro-crate-profile/tree/{version}/profile"

let name = "ISA RO-Crate Profile"

let license = License(
        iri = "https://mit-license.org/",
        name = "MIT License"
    )

let description = "An RO-Crate profile for representing the ISA (Investigation, Study, and Assay) metadata framework in Research Object Crates (RO-Crates)."

let keywords = ResizeArray [
    "RO-Crate"
    "Research Object Crate"
    "ISA"
    "Investigation"
    "Study"
    "Assay"
    "Process"
    "Metadata Standard"
    "Bioschemas"
    "FAIR Data"
    "ARC"
    "Annotated Research Context"
    "Data Management"
]

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
        authors = ResizeArray authors,
        version = version,
        keywords = keywords,
        usedTypes = types,
        resourceDescriptors = resourceDescriptors,
        publisher = publisher
    )

let profile = 
    Profile(
        rootEntity,
        license = license
    )

let string = profile.ToROCrateJsonString(spaces = 2)

System.IO.File.WriteAllText("profile/ro-crate-metadata.json", string)
