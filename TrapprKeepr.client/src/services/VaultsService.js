import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
class VaultsService {
    // STUB Create Vault
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('[CREATED VAULT]', res.data)
        const newVault = new Vault(res.data)
        AppState.myVaults.push(new Vault(res.data))
        return newVault
    }

    // STUB NOT NEEDED -  get All Vaults for all people - In our app this endpoint is disallowed- no Use Case for this function



    // STUB getVaultsByProfile - single profile with its many vaults
    async getVaultsByProfile(profileId) {
        const response = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('[MY VAULTS]', response.data)
        const myVaults = AppState.myVaults = response.data.map(v => new Vault(v))
        // AppState.vaults = myVaults;
        return myVaults
    }

    // STUB Get Vault Details - get info on a single vault with its ID
    async getVaultDetails(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}`)
        logger.log('[GOT VAULT BY ID ]', res.data)
        const activeVault = AppState.activeVault = new Vault(res.data)
        return activeVault;
    }

}
export const vaultsService = new VaultsService()