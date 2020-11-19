# FHIR-Consent-Samples
Contains FHIR sample for  Consent based authorization

# Architecture
This code sits in front of a FHIR endpoint

# Use
1. Clone repo
2. Open api/consent-api.sln
3. Run solution

## FHIR Credentials
Right Click on consent-api project.

- Click '*Manage User Secrets*' and place the *Tenant Id*, *App Client Id*, *App Client Secret* in the appropriate keys.


## Calls available
### Pagient
```GET /api/patient?id=$ID&upn=$UPN```
Gets patient resource with id=$ID from FHIR endpoint if there is an active, unexpiered consent resource for patient $ID with a security code of $UPN

### Consent
```GET /api/consents?id=$ID&upn=$UPN```
Gets a list of consent resrouces for patient with id of $ID that include security code of $UPN

# Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content
in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode),
see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the
[LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation
may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries.
The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks.
Microsoft's general trademark guidelines can be found at http://go.microsoft.com/fwlink/?LinkID=254653.

Privacy information can be found at https://privacy.microsoft.com/en-us/

Microsoft and any contributors reserve all other rights, whether under their respective copyrights, patents,
or trademarks, whether by implication, estoppel or otherwise.


***