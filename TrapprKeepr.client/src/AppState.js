// APPSTATE
import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({

  //  SECTION AUTH ZERO
  // STUB AUTH ZERO
  user: {},



  //  SECTION ACCOUNT ENPOINTS_APPSTATE DATA TYPES

  // STUB ACCOUNT
  /** @type {import('./models/Account.js').Account} */
  account: {},

  // STUB PROFILE - - Get a User's Profile
  /** @type {import('./models/Account.js').Account} */
  profile: {},

  // {{endpoint}}/account/vaults
  /** @type {import('./models/Account.js').Account} */
  myVaults: [],

  // {{endpoint}}/api/profiles/{{profileId}}/keeps
  // STUB KEEPS - Get a Profile's Keeps
  /** @type {import('./models/Keep.js').Keep[]} */
  myKeeps: [],




  //  SECTION PROFILE ENPOINTS_APPSTATE DATA

  // {{endpoint}}/api/profiles/{{profileId}}
  // STUB ACTIVE PROFILE - Get a User's Profile
  /** @type {import('./models/Account.js').Account} */
  activeProfile: null,

  // {{endpoint}}/api/profiles/{{profileId}}/keeps
  // STUB KEEPS on Profile - Get a User's Keeps
  /**@type {Keep} */
  profileKeeps: [],

  // {{endpoint}}/api/profiles/{{profileId}}/vaults
  // STUB Vaults on Profile - get a User's Vaults
  /** @type {import('./models/Vault.js').Vault[]} */
  profileVaults: [],



  // SECTION  PROFILE and/or ACCOUNT ENDPOINTS_APPSTATE DATA

  // {{endpoint}}/api/vaults/{{vaultId}}
  // STUB ACTIVE VAULT - Get Vault by Id - Profile or Account
  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,

  // {{endpoint}}/api/keeps/{{keepId}}
  // STUB ACTIVE KEEP - Get Keep By Id
  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,


  // {{endpoint}}/api/keeps
  // STUB ALL KEEPS - Get All Keeps - System Wide Get
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],





  // SECTION VAULT KEEPS ENDPOINTS_DATATYPES

  // STUB ACCOUNT OR PROFILE Get Keeps in a Vault - Keeps in a Singluar Vault
  // {{ endpoint }}/api/keeps
  vaultKeeps: [],

  // {{endpoint}}/account/vaults
  /** @type {import('./models/Vault.js').Vault} */
  activeVault: [],

})