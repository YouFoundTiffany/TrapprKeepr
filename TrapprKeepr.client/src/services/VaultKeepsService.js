// VAULT-KEEPS SERVICE
import { logger } from "../utils/Logger"
import { AppState } from "../AppState.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

    // Create VaultKeep
    async createVaultKeep(vaultId, vaultKeepData) {
        const res = await api.post(`api/vaults/${vaultId}/keeps`, vaultKeepData);
        logger.log('[CREATED VAULTKEEP]', res.data);
        const newVaultKeep = new VaultKeep(res.data);
        AppState.vaultKeeps.push(newVaultKeep);
        return newVaultKeep;
    }

    // Get Keeps in Vault
    // vaults/{{vaultId}}/keeps
    async getVaultKeeps(vaultId) {

        const res = await api.get(`api/vaults/${vaultId}/keeps`);
        logger.log('[❤️‍🔥GOT ALL VAULTKEEPS]', res.data);
        // AppState.vaultKeeps = res.data.map(vaultKeep => new VaultKeep(vaultKeep));
        // return AppState.vaultKeeps;
    }

    // Delete VaultKeep by ID
    async deleteVaultKeep(vaultKeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`);
        logger.log('[DELETED VAULTKEEP]', res.data);
        let indexToRemove = AppState.activeVaultKeep.findIndex(vkeep => vkeep.id === vaultKeepId);
        AppState.activeVaultKeep.splice(indexToRemove, 1);
    }
}

export const vaultKeepsService = new VaultKeepsService();
