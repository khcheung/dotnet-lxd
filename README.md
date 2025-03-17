# dotnet-lxd
LXD .Net Client

Basic client to invoke LXD api for basic functions.


## Self Signed Certificate
- CertHelper
  - Generate Self Signed Cert in PEM format and Store
  - Load Cert in PEM format for LXD Client


## LXD Client Function List (Implemented)
- Certificates
  - Add Cert with Token (CertificatePublicPostAsync) - GET (/1.0/certificates?public)
- Identities
  - Get OIDC (AuthIdentitiesOidcGetAsync) - GET (/1.0/auth/identities/oidc)
- Instances
  - List Instances (InstancesGetAsync) - GET (/1.0/instances)
  - List Instances (InstancesGetRecursivelyAsync) - GET (/1.0/instances?recursion=1)
  - Get Instance (InstancesGetAsync) - GET (/1.0/instances/{name})
  - Create Instance (InstancesPostAsync) - POST (/1.0/instances)
  - Update Instance (InstancesPutAsync) - PUT (/1.0/instances/{name})
  - Delete Instance (InstancesDeleteAsync) - DELETE (/1.0/instances/{name})
- Networks
  - List Networks (NetworksGetAsync) - GET (/1.0/networks)
  - List Networks (NetworksGetRecursivelyAsync) - GET (/1.0/networks?recursion=1)
  - Create Networks (NetworkPostAsync) - POST (/1.0/networks)
  - Update Network (NetworkPutAsync) - PUT (/1.0/networks/{name})
  - Delete Networks (NetworkDeleteAsync) - DELETE (/1.0/networks)
- Storages
  - List Storages (StoragesGetAsync) - GET (/1.0/storage-pools)
  - List Storages (StoragesGetRecursivelyAsync) - GET (/1.0/storage-pools?recursion=1)
  - Get Storage (StoragesGetAsync) - GET (/1.0/storage-pools/{name})
  - List StorageVolumes (StorageVolumeGetAsync) - GET (/1.0/storage-volumes)
  - List StorageVolumes (StorageVolumeGetRecursivelyAsync) - GET (/1.0/storage-volumes?recursion=1)

## LXD Client (PowerShell)

Unix/Linux Config (~/.config/dotnetlxd/config.json)

### PowerShell Cmdlet List
- Instances
  - Get-LXDInstances
- Networks
  - Get-LXDNetworks
- Storages
  - Get-LXDStorages

