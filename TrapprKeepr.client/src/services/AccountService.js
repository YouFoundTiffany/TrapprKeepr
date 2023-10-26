import { AppState } from '../AppState.js'
import { Account, Profile } from '../models/Account.js'
import { Keep } from '../models/Keep.js'
import { Vault } from '../models/Vault.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'
import { api } from './AxiosService.js'


class AccountService {
  async getAccount() {
    try {

      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getTheAccount() {
    const res = await api.get('/account')
    const profile = new Profile(res.data)
    AppState.activeProfile = profile

  }


  async getProfile(profileId) {
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('[GETTING PROFILE]', res.data)
    const profile = new Profile(res.data)
    AppState.activeProfile = profile
  }



  async getProfileById(profileId) {
    AppState.activeProfile = null
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('🙆', res.data)
    AppState.activeProfile = new Profile(res.data)
  }



  async editProfile(updateData) {
    const res = await api.put('/account', updateData)
    logger.log('🙆🪄', res.data)
  }



}



export const accountService = new AccountService()
