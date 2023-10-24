// APPSTATE
import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  // STUB AUTH ZERO
  user: {},

  // STUB ACCOUNT
  /** @type {import('./models/Account.js').Account} */
  account: {},

  // STUB PROFILE
  /** @type {import('./models/Account.js').Account} */
  profile: {},

  // STUB ACTIVE PROFILE?
  /** @type {import('./models/Account.js').Account| null} */
  activeProfile: null,

  // STUB VAULTS
  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [],
  // STUB VAULTS
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [],

  // STUB ACTIVE VAULT?
  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,

  // STUB ACTIVE VAULT KEEPS?
  // REVIEW keeps on a single Vault ID
  /** @type  {import('./models/Keep.js').Keep | null} */
  activeVaultKeeps: [],

  // STUB KEEPS
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  // STUB KEEPS
  /** @type {import('./models/Keep.js').Keep[]} */
  myKeeps: [],

  // STUB ACTIVE KEEP
  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,

})
