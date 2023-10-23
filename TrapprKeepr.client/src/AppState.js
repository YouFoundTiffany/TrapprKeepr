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

  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,

  // REVIEW
  /** @type  {import('./models/Keep.js').Keep | null} */
  activeVaultKeeps: [],

  // REVIEW
  /** @type {import('./models/VaultKeep.js').vaultsVKeeps | null}*/
  activeKeepVKeeps: [],

  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],

  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,

  /** @type {import('./models/Keep.js').Keep | null} */
  myKeeps: null,

  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  vaultsVKeeps: [],

  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  myVKeekps: []

})
