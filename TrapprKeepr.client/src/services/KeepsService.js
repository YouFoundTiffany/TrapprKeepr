import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
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
        // debugger
        const res = await api.get('api/keeps')
        logger.log('📷 got keeps', res.data)
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
    // async getPicturesByAlbumId(albumId) {
    //     const res = await api.get(`api/albums/${albumId}/pictures`)
    //     logger.log('🖼️ album pictures', res.data)
    //     AppState.activeAlbumPictures = res.data.map(pic => new Picture(pic))
    // }

    // STUB CreateKeep
    // async getCollaboratorsByAlbumId(albumId) {
    //     const res = await api.get(`api/albums/${albumId}/collaborators`)
    //     logger.log('📷🤝', res.data)
    //     AppState.activeAlbumCollaborators = res.data.map(collab => new Collaborator(collab))
    // }
}

export const keepsService = new KeepsService()
