import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Account.js').Account} */
  profile: {},

  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [],

  // Logged in User/Account holder's Keeps
  /** @type {import('./models/Vault.js').Vault | null} */
  myVaults: null,

  // Profile or User's Keeps not necessarily the logged in user.
  /** @type {import('./models/Vault.js').Vault | null} */
  profileVaults: null,

  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,

  // REVIEW keeps on a single Vault ID
  /** @type  {import('./models/Keep.js').Keep | null} */
  activeVaultKeeps: [],

  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],

  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,

  // Logged in User/Account holder's Keeps
  /** @type {import('./models/Keep.js').Keep | null} */
  myKeeps: null,

  // Profile or User's Keeps not necessarily the logged in user.
  /** @type {import('./models/Keep.js').Keep | null} */
  profileKeeps: null,



})
