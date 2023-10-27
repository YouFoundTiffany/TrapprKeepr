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
