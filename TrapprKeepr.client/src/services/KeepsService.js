import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { VaultKeep } from "../models/VaultKeep.js"
// import { VaultKeep } from "../models/VaultKeep.js"
// import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"




class KeepsService {

    // STUB CreateKeep
    async CreateKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        logger.log('📷 created keep', res.data)
        const newKeep = new Keep(res.data)
        AppState.keeps.unshift(newKeep)
        // AppState.keeps.push(new Keep(res.data))
        return newKeep // this is returned so the vue component has it for a router push
    }
    // STUB GetKeep
    async getKeeps() {
        const res = await api.get('api/keeps')
        logger.log('[got keeps]', res.data)
        const keeps = AppState.keeps = res.data.map(keep => new Keep(keep))
        AppState.keeps = keeps
    }

    // STUB GetKeepByVaultId
    // async getAlbumById(albumId) {
    //     const res = await api.get(`api/albums/${albumId}`)
    //     logger.log('📷 got one album', res.data)
    //     AppState.activeAlbum = new Album(res.data)
    // }

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

    // STUB CreateKeep
    // async getCollaboratorsByAlbumId(albumId) {
    //     const res = await api.get(`api/albums/${albumId}/collaborators`)
    //     logger.log('📷🤝', res.data)
    //     AppState.activeAlbumCollaborators = res.data.map(collab => new Collaborator(collab))
    // }
}

export const keepsService = new KeepsService()
