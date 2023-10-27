// COMBO ACCOUNT AND PROFILE SERVICE - SEE ASSOCIATED SECTIONS
import { AppState } from '../AppState.js'
import { Account, Profile } from '../models/Account.js'
import { Keep } from '../models/Keep.js'
import { Vault } from '../models/Vault.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { api } from './AxiosService.js'


class AccountService {



  // SECTION ACCOUNT SECTION

  // STUB This is The Account Holder who is logged in
  async getAccount() {
    try {

      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  // STUB Get Account Vaults - MyVaults
  async getMyVaults() {
    const res = await api.get(res.data)
    logger.log('[GETTING MY-VAULTS]', res.data)

  }







  // SECTION PROFILES SECTION

  //STUB  Get a User's Profile
  // GET {{endpoint}}/api/profiles/{{profileId}}
  async getProfileById(profileId) {
    // nulling out the active profile in case it was set to another profile
    AppState.activeProfile = null
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('[GETTING PROFILE]', res.data)
    // new instance of your data
    const profile = new Profile(res.data)
    // setting the active profile to the one we just got back from the server Global Appstate
    AppState.activeProfile = profile
  }






  // FIXME
  async editProfile(data) {
    const res = await api.put(`api/profiles/${profileId}`, data)
    const profileId = AppState.account.id
    logger.log('profileId')
    AppState.profile = new Profile(res.data)
  }

  // STUB Get all Keeps with this Profile Id
  // Get a User's Keeps
  // GET {{endpoint}}/api/profiles/{{profileId}}/keeps
  async getProfilesKeeps(profileId) {

    const res = await api.get(`api/profiles/${profileId}/keeps`)
    // logger.log("🦄 This Profile's Keeps", res.data)
    const profileKeeps = res.data
    AppState.profileKeeps = res.data.map(k => new Keep(k))
    // logger.log('[ProfileKeeps!]', AppState.profileKeeps)
    return profileKeeps;
  }


  // STUB Get all Vaults with this Profile Id
  // Get a User's Vaults
  // GET {{endpoint}}/api/profiles/{{profileId}}/vaults
  // Profile Page
  async getProfilesVaults(profileId) {

    const res = await api.get(`api/profiles/${profileId}/vaults`)

    logger.log("[Profile's Vaults!]", res.data)

    const profileVaults = res.data
    AppState.profileVaults = res.data.map(v => new Vault(v))

    logger.log(['[ProfileVaults]!', AppState.profileVaults])
    return profileVaults;
  }

}



export const accountService = new AccountService()
