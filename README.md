# dotnet-lxd
LXD .Net Client

Basic client to invoke LXD api for basic functions.


## Self Signed Certificate
- CertHelper
  - Generate Self Signed Cert in PEM format and Store
  - Load Cert in PEM format for LXD Client


## LXD Function List
- Certificates
  - Add Cert with Token - GET (/1.0/certificates?public)
- Identities
  - Get OIDC - GET (/1.0/auth/identities/oidc)
- Instances
  - List Instances - GET (/1.0/instances)
  - Get Instance - GET (/1.0/instances/{name})
  - Create Instance - POST (/1.0/instances)