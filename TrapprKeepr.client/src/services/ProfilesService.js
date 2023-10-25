import { AppState } from "../AppState.js"
import { Profile } from "../models/Account.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class ProfilesService {

    async getProfile(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        logger.log('[GETTING PROFILE]', res.data)
        const profile = new Profile(res.data)
        AppState.activeProfile = profile
    }
    // FIXME
    async editProfile(data) {
        const res = await api.put(`api/profiles/${profileId}`, data)
        const profileId = AppState.account.id
        logger.log('profileId')
        AppState.profile = new Profile(res.data)
    }

    async getProfileById(profileId) {
        // logger.log('profile', res.data)
        // AppState.activeProfile = null
        // const res = await api.get(`api/profiles/${profileId}`)
        // AppState.activeProfile = new Profile(res.data)
    }


    // STUB Get all Keeps with this Profile Id
    async getProfilesKeeps(profileId) {

        const res = await api.get(`api/profiles/${profileId}/keeps`)
        // logger.log("🦄 This Profile's Keeps", res.data)

        const profileKeeps = res.data
        AppState.profileKeeps = res.data.map(k => new Keep(k))
        // logger.log('[ProfileKeeps!]', AppState.profileKeeps)
        return profileKeeps;
    }
    // STUB Get all Vaults with this Profile Id
    async getProfilesVaults(profileId) {


        const res = await api.get(`api/profiles/${profileId}/vaults`)

        // logger.log("🔐 This Profile's Vaults", res.data)

        const profileVaults = res.data
        AppState.profileVaults = res.data.map(v => new Vault(v))

        // logger.log(['[ProfileVaults]!', AppState.profileVaults])
        return profileVaults;

    }
}



export const profilesService = new ProfilesService()