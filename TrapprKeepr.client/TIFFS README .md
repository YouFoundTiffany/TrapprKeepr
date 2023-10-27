
KEEPS
Create Keep
POST {{endpoint}}/api/keeps

✅Get All Keeps
GET {{endpoint}}/api/keeps

Get Keep by Id
GET {{endpoint}}/api/keeps/{{keepId}}

Edit Keep
PUT {{endpoint}}/api/keeps/{{keepId}}

Delete Keep
DELETE{{endpoint}}/api/keeps/{{keepId}}


	 VAULTS
Create Vault
POST {{endpoint}}/api/vaults

Get Vault by Id
GET {{endpoint}}/api/vaults/{{vaultId}}

Edit Vault
PUT {{endpoint}}/api/vaults/{{vaultId}}

Delete Vault
DELETE {{endpoint}}/api/vaults/{{vaultId}}


	 VAULT KEEPS

Create VaultKeep
POST {{endpoint}}/api/vaultkeeps

Get Keeps in Vault
GET {{endpoint}}/api/vaults/{{vaultId}}/keeps

Delete VaultKeep
DELETE {{endpoint}}/api/vaultkeeps/{{vaultKeepId}}


	 PROFILE
✅Get a User's Profile
GET {{endpoint}}/api/profiles/{{profileId}}

✅Get a User's Keeps
GET {{endpoint}}/api/profiles/{{profileId}}/keeps

✅Get a User's Vaults
GET {{endpoint}}/api/profiles/{{profileId}}/vaults


	 ACCOUNT

✅Get My Vaults
GET {{endpoint}}/account/vaults


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

  // NOTE NEVER GOING HAVE A USE CASE FOR GETTING ALL VAULTS
  // NOTE NO vaults DATATYPE IN APPSTATE



  // SECTION VAULT KEEPS ENDPOINTS_DATATYPS

  // STUB ACCOUNT OR PROFILE Get Keeps in a Vault - Keeps in a Singluar Vault
  // {{ endpoint }}/api/keeps
  vaultKeeps: [],

  import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard, authSettled } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage'),
    beforeEnter: authSettled
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  },
  {
    path: '/profile/:profileId',
    name: 'Profile',
    component: loadPage('ProfilePage'),
    // beforeEnter: authSettled

  },
  // {
  //   path: '/profile/:userId',
  //   name: 'UserProfile',
  //   component: ('UserProfilePage'),
  // },
  {

    path: '/edit-profile/:profileId',
    name: 'Edit Profile',
    component: loadPage('EditProfileForm'),
    // FIXME Do I need an AuthGuard or Settled?
  },
  {
    path: '/vault/:vaultId',
    name: 'Vault Details',
    component: loadPage('VaultDetailsPage'),
    beforeEnter: authSettled
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
