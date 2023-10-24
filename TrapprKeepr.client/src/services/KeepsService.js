import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
class KeepsService {
    // STUB createKeep
    async createKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        logger.log('📷 created keep', res.data)
        const newKeep = new Keep(res.data)
        AppState.keeps.push(new Keep(res.data))
        return newKeep
    }

    // STUB GetKeep
    async getKeeps() {
        const res = await api.get('api/keeps')
        logger.log('[got keeps]', res.data)
        // const keeps = AppState.keeps = res.data.map(keep => new Keep(keep))
        // AppState.keeps = keeps
        const keeps = res.data.map(keep => new Keep(keep))
        AppState.keeps = keeps;
    }

    // STUB GetKeepByProfileId
    async getKeepsByProfile() {
        logger.log(AppState.account.id)
        // let res = await api.get(`/profile/keeps`) ?????
        let res = await api.get(`/account/keeps`)
        logger.log(res.data)
        AppState.myKeeps = res.data.map(keep => new Keep(keep))
        logger.log(AppState.profileKeeps)
    }

    // STUB get all keeps on a single Vault ID
    async getKeepsbyVaultId(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        logger.log('[keeps on this specific album]', res.data)
        AppState.activeVaultKeeps = res.data.map(vk => new VaultKeep(vk))
    }

}

export const keepsService = new KeepsService()
