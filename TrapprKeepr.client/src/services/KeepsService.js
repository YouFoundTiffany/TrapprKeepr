// CLIENT KEEPS SERVICE
import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {
    // STUB createKeep
    async createKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        logger.log('[CREATED KEEP]', res.data)
        const newKeep = new Keep(res.data)
        AppState.keeps.push(new Keep(res.data))
        return newKeep
    }

    // STUB GetKeep
    async getKeeps() {
        const res = await api.get('api/keeps')
        // logger.log('[GOT ALL KEEPS]', res.data)
        // const keeps = AppState.keeps = res.data.map(keep => new Keep(keep))
        // AppState.keeps = keeps
        const keeps = res.data.map(keep => new Keep(keep))
        AppState.keeps = keeps;
    }

    // STUB getKeepById
    async getKeepById(keepId) {
        const res = await api.get(`api/keeps/${keepId}`)
        logger.log('[GOT KEEP BY ID]', res.data)
        const activeKeep = AppState.activeKeep = new Keep(res.data)
        return activeKeep
    }

    // STUB GetKeepByProfileId
    async getKeepsByProfile(profileId) {

        const response = await api.get(`api/profiles/${profileId}/keeps`)
        logger.log('[MY KEEPS]', response.data)
        const myKeeps = AppState.keeps = response.data.map(k => new Keep(k))
        return myKeeps;
    }
    // GET KEEP DETAILS
    async getKeepDetails(keepId) {
        logger.log('api/keeps/undefined????')
        const res = await api.get(`api/keeps/${keepId}`)
        logger.log('[GOT KEEP BY ID ]', res.data)

        AppState.activeKeep = new Keep(res.data)
    }


    // STUB GET KEEPS IN A VAULT get all keeps on a single Vault ID
    // {{endpoint}}/api/vaults/{{vaultId}}/keeps
    async getKeepsbyVaultId(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        logger.log('[keeps on this specific album]', res.data)
        AppState.activeVaultKeeps = res.data.map(vk => new VaultKeep(vk))
    }


}

export const keepsService = new KeepsService()
